using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class CharGenerator:Generator<char, int>
    {
        public override char Generate()
        {
            return Generate(char.MinValue, char.MaxValue);
        }

        public override char Generate(int min, int max)
        {
            return (char)Random.Next(min, max);
        }
    }
}