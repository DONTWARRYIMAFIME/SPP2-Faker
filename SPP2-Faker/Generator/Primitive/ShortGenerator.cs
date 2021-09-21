using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class ShortGenerator:Generator<short, short>
    {
        public override short Generate()
        {
            return Generate(short.MinValue, short.MaxValue);
        }

        public override short Generate(short min, short max)
        {
            return (short)Random.Next(min, max);
        }
    }
}