using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class IntGenerator:Generator<int, int>
    {
        public override int Generate()
        {
            return Generate(int.MinValue, int.MaxValue);
        }

        public override int Generate(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}