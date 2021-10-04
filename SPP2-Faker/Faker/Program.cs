using System;
using System.Collections.Generic;

namespace SPP2_Faker.Faker
{
    class Program
    { 
        static void Main(string[] args)
        {
            var faker = new Faker();
            //var foo = faker.Create<uint>();
            var cycleDependencyTest = faker.Create<List<bool>>();
            Console.Write(cycleDependencyTest);
            
            Console.WriteLine(cycleDependencyTest.Count);
            
            foreach (var i in cycleDependencyTest)
            {
                Console.Write(i + " ");
            }
        }
    }
}