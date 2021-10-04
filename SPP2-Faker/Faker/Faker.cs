using System;
using System.Linq;
using System.Reflection;
using SPP2_Faker.Generator;

namespace SPP2_Faker.Faker
{
    public class Faker
    {
        public T Create<T>()
        {
            var instance = Create(typeof(T));
            return instance != null ? (T)instance : default;
        }

        private object Create(Type type)
        {
            object generated;
            
            var generator = GeneratorsDictionary.GetGenerator(type);
            if (generator != null)
            {
                return generator.Generate();
            }
            
            var constructor = GetConstructorWithMaxParametersCount(type);
            if (constructor != null)
            {
                var result =  CreateUsingConstructor(constructor);
                // Console.WriteLine(result);
                // FillPublicFields(result);
                // Console.WriteLine(result);
                // FillPublicProperties(result);
                // Console.WriteLine(result);
                return result;
            }
            
            return null;
        }

        private object CreateUsingConstructor(ConstructorInfo constructor)
        {
            try
            {
                return constructor.Invoke(constructor.GetParameters()
                    .Select(parameterInfo => Create(parameterInfo.ParameterType))
                    .ToArray());
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }

        private void FillPublicFields(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                field.SetValue(obj, Create(field.FieldType));
            }
        }

        private void FillPublicProperties(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(obj, Create(property.PropertyType));
                }
            }
        }
        
        private ConstructorInfo GetConstructorWithMaxParametersCount(Type type)
        {
            var constructors = type.GetConstructors();

            if (constructors.Length == 0)
            {
                return null;
            }

            var maxParametersCount = constructors
                .Where(c => !c.IsPrivate)  
                .Select(c => c.GetParameters().Length)
                .Max();
            
            return constructors.FirstOrDefault(c => c.GetParameters().Length == maxParametersCount);
        }
        
    }
    
}