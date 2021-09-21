using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class BoolGenerator:Generator<bool, int>
    {
        public override bool Generate()
        {
            return Generate(0, 1);
        }

        public override bool Generate(int min, int max)
        {
            return Convert.ToBoolean(Random.Next(min, max));
        }
    }
}