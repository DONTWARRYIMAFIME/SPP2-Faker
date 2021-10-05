using System.Collections.Generic;

namespace Faker.Test.TestClasses
{
    public class CycleDependencyExampleClass
    {
        public Foo Foo { get; set; }
    }

    public class Foo
    {
        public List<Bar> List { get; set; }
    }

    public class Bar
    {
        public FooBar FooBar { get; set; }
    }

    public class FooBar
    {
        public Foo Foo { get; set; }
    }
    
}