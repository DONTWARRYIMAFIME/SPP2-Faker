using System;
using System.Collections.Generic;
using Generator.SDK;

namespace CustomGenerator
{
    public class CityGenerator:IGenerator
    {
        public Type Type => typeof(string);
        
        private readonly Random _random = new();
        private readonly List<string> _cities;

        public CityGenerator()
        {
            _cities = new List<string>()
            {
                "Minsk", "Orsha", "Vitebsk", "Brest", "Grodno"
            };
        }
        
        public object Generate()
        {
            return _cities[_random.Next(_cities.Count)];
        }
    }
}