using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class FloatGenerator:Generator<float, float>
    {
        public override float Generate()
        {
            return Generate(float.MinValue, float.MaxValue);
        }

        public override float Generate(float min, float max)
        {
            return (float)Random.NextDouble() * (max - min) + min;
        }
    }
}