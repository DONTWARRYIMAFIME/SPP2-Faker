using System;
using System.Collections.Generic;
using Generator.SDK;

namespace CustomGenerator
{
    public class NameGenerator:IGenerator
    {
        public Type Type => typeof(string);
        
        private readonly Random _random = new();
        private readonly List<string> _cities;

        public NameGenerator()
        {
            _cities = new List<string>()
            {
                "Vlas", "Arseniy", "Oleg", "Erog", "Vanya", "Liza", "Denis", "Alex", "Anton", "Nastya"
            };
        }
        
        public object Generate()
        {
            return _cities[_random.Next(_cities.Count)];
        }
    }
}