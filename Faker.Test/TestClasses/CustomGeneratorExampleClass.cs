namespace Faker.Test.TestClasses
{
    public class CustomGeneratorExampleClass
    {
        public string City { get; set; }
        public string Name { get; }
        
        public string RandomString { get; set; }

        public CustomGeneratorExampleClass(string name)
        {
            Name = name;
        }
    }
}