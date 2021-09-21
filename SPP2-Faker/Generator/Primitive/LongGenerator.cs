using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class LongGenerator:Generator<long, long>
    {
        public override long Generate()
        {
            return Generate(long.MinValue, long.MaxValue);
        }

        public override long Generate(long min, long max)
        {
            long result = Random.Next((int)(min >> 32), (int)(max >> 32));
            result = (result << 32);
            result = result | (uint)Random.Next((int)min, (int)max);
            return result;
        }
    }
}