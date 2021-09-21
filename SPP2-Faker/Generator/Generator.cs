using System;

namespace SPP2_Faker.Generator
{
    public abstract class Generator<T, TU> : IGenerator<T, TU>
    {
        protected readonly Random Random = new Random();

        public abstract T Generate();

        public abstract T Generate(TU min, TU max);
    }
}