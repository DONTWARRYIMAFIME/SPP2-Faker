using System;
using System.Collections.Generic;

namespace Faker.UsageExample
{
    public class User
    {
        public string Name { get; }

        public DateTime Dob;

        public ulong Id;
        public string City { get; }
        
        public string Password;
        
        public List<Post> Posts;

        public User(DateTime dob, ulong id, string password, string name, string city)
        {
            Dob = dob;
            Id = id;
            Password = password;
            Name = name;
            City = city;
        }

        private User(DateTime dob, ulong id, string city, string password)
        {
            Dob = dob;
            Id = id;
            City = city;
            Password = password;
        }
        
        public User(DateTime dob, ulong id, string city)
        {
            Dob = dob;
            Id = id;
            City = city;
        }
        
        public User(DateTime dob, ulong id)
        {
            Dob = dob;
            Id = id;
        }
        
    }
}