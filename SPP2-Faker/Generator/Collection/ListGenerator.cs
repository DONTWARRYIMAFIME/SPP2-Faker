using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Generator.SDK;

namespace SPP2_Faker.Generator.Collection
{
    public class ListGenerator:ICollectionGenerator
    {
        public Type Type => typeof(List<>);

        private readonly Random _random;

        public ListGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate(Type type, Func<Type, object> method)
        {
            var argumentType = type.GetGenericArguments().Single();
            var result = (IList)Activator.CreateInstance(type);

            var count = _random.Next(8) + 8;
            for (var i = 0; i < count; i++)
            {
                result?.Add(method(argumentType));
            }
        
            return result;
        }
        
    }
}