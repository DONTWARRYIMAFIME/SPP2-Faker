using System;

namespace Faker.UsageExample.Example1
{
    public class Like
    {
        public DateTime DateTime { get; set; }
        public long AuthorId { get; }

        public Like(long authorId)
        {
            AuthorId = authorId;
        }
    }
}