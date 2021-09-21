using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class DecimalGenerator:Generator<decimal, decimal>
    {
        public override decimal Generate()
        {
            return Generate(decimal.MinValue, decimal.MaxValue);
        }

        public override decimal Generate(decimal min, decimal max)
        {
            return (decimal)Random.NextDouble() * (max - min) + min;
        }
    }
}