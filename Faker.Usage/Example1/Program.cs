using System;
using System.Text.Json;
using CustomGenerator;
using SPP2_Faker.Faker;

namespace Faker.UsageExample.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FakerConfig(); 
            
            config.Add<User, string, CityGenerator>(user => user.City);
            config.Add<User, string, NameGenerator>(user => user.Name);
            var faker = new Faker(config);
            
            var user = faker.Create<User>();

            var jsonOptions = new JsonSerializerOptions() { IgnoreNullValues = true, IncludeFields = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(user, jsonOptions);
            Console.WriteLine(json);
        }
    }
}