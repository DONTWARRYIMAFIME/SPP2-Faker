using System;
using System.Collections.Generic;
using System.Linq;
using Generator.SDK;
using SPP2_Faker.Generator.Primitive;
using SPP2_Faker.Generator.System;

namespace SPP2_Faker.Generator
{
    public static class GeneratorsDictionary
    {
        private static readonly Dictionary<Type, IGenerator> Generators = new();
        private static readonly Random Random = new();
        
        static GeneratorsDictionary()
        {
            SetupGenerators();
            LoadPluginGenerators();
        }

        private static void SetupGenerators()
        {
            Generators.Add(typeof(bool), new BoolGenerator(Random));
            Generators.Add(typeof(byte), new ByteGenerator(Random));
            Generators.Add(typeof(char), new CharGenerator(Random));
            Generators.Add(typeof(decimal), new DecimalGenerator(Random));
            Generators.Add(typeof(double), new DoubleGenerator(Random));
            Generators.Add(typeof(float), new FloatGenerator(Random));
            Generators.Add(typeof(int), new IntGenerator(Random));
            Generators.Add(typeof(short), new ShortGenerator(Random));
            Generators.Add(typeof(DateTime), new DateTimeGenerator(Random));
        }

        private static void LoadPluginGenerators()
        {
            var pluginGenerators = PluginManager.LoadPlugins(Random);
            Console.WriteLine(pluginGenerators.Count + " plugin(s) found");
            Generators.Append(pluginGenerators);
        }
        
        private static void Append<T, TU>(this Dictionary<T, TU> first, Dictionary<T, TU> second)
        {
            second.ToList().ForEach(pair => first[pair.Key] = pair.Value);
        }
        
        public static IGenerator GetGenerator(Type type)
        {
            Generators.TryGetValue(type, out var result);
            return result;
        }
        
    }
}