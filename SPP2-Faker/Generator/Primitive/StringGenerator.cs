using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class StringGenerator:Generator<string, int>
    {
        public override string Generate()
        {
            return Generate(0, int.MaxValue);
        }

        public override string Generate(int min, int max)
        {
            byte[] bytes = new byte[Random.Next(0, max)];
            Random.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}