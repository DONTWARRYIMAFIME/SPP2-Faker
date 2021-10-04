using System;

namespace SPP2_Faker.Faker
{
    class Program
    { 
        static void Main(string[] args)
        {
            var faker = new Faker();
            var foo = faker.Create<long>();
            Console.WriteLine(foo);
        }
    }
}