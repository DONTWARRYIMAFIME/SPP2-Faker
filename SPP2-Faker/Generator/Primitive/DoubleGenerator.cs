using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class DoubleGenerator:Generator<double, double>
    {
        public override double Generate()
        {
            return Generate(double.MinValue, double.MaxValue);
        }

        public override double Generate(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }
    }
}