using System;
using System.Linq;
using System.Reflection;
using SPP2_Faker.Generator;

//TODO: implement unit test
//TODO: OPTIONAL. Implement custom generators support

namespace SPP2_Faker.Faker
{
    public class Faker
    {
        private readonly CycleDependencyResolver _resolver = new();
        
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            var generator = GeneratorsDictionary.GetGenerator(type);
            if (generator != null)
            {
                return generator.Generate();
            }
            
            if (type.IsGenericType)
            {
                var collectionType = type.GetGenericTypeDefinition();
                var argumentType = type.GetGenericArguments().Single();

                if (_resolver.IsCycleDependencyDetected(argumentType))
                {
                    return null;
                }
                
                _resolver.PushType(argumentType);
                
                var collectionGenerator = GeneratorsDictionary.GetCollectionGenerator(collectionType);
                if (collectionGenerator != null)
                {
                    return collectionGenerator.Generate(type, argumentType, Create);
                }
                
                _resolver.PopType();
            }
            else if (type.IsClass)
            {
                if (_resolver.IsCycleDependencyDetected(type))
                {
                    return null;
                }
                
                _resolver.PushType(type);
                
                var constructor = GetConstructorWithMaxParametersCount(type);
                if (constructor == null)
                {
                    throw new ArgumentException("Class: " + type + " has no public constructors");
                }
                
                var result =  CreateUsingConstructor(constructor);
                FillPublicFields(result);
                FillPublicProperties(result);
                
                _resolver.PopType();

                return result;
            }
            
            try
            {
                return Activator.CreateInstance(type);
            }
            catch (MissingMethodException)
            {
                return default;
            }
        }

        private object CreateUsingConstructor(ConstructorInfo constructor)
        {
            try
            {
                return constructor.Invoke(constructor.GetParameters()
                    .Select(parameterInfo => Create(parameterInfo.ParameterType))
                    .ToArray());
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        private void FillPublicFields(object instance)
        {
            FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                field.SetValue(instance, Create(field.FieldType));
            }
        }

        private void FillPublicProperties(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(instance, Create(property.PropertyType));
                }
            }
        }
        
        private static ConstructorInfo GetConstructorWithMaxParametersCount(Type type)
        {
            var constructors = type.GetConstructors().ToList();
            constructors.Sort((x, y) =>
            {
                var xx = x.GetParameters().Length;
                var yy = y.GetParameters().Length;
                return yy.CompareTo(xx);
            });
            return constructors.FirstOrDefault(constructor => constructor.IsPublic);
        }

    }
    
}