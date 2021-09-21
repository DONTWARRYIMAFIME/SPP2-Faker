using System;

namespace SPP2_Faker.Generator.Primitive
{
    public class ByteGenerator:Generator<byte, byte>
    {
        public override byte Generate()
        {
            return Generate(byte.MinValue, byte.MaxValue);
        }
        
        public override byte Generate(byte min, byte max)
        {
            return (byte)Random.Next(min, max);
        }
    }
}