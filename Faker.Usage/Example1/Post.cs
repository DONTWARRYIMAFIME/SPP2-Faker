using System;
using System.Collections.Generic;

namespace Faker.UsageExample.Example1
{
    public class Post
    {
        private readonly DateTime _publishDateTime;
        public string Message;
        public float Rating;
        
        public List<Like> Likes { get; set; }
        
        public long AuthorId { get; }

        public User User;
        
        public Post(DateTime publishDateTime, long authorId)
        {
            _publishDateTime = publishDateTime;
            AuthorId = authorId;
        }

    }
}