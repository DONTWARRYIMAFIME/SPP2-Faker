using System;

namespace SPP2_Faker.Generator
{
    public interface IGenerator<out T, in TU>
    {
        T Generate();
        
        T Generate(TU min, TU max);
    }
}