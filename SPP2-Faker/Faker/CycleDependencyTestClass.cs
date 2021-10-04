using System;
using System.Collections.Generic;

namespace SPP2_Faker.Faker
{
    public class CycleDependencyTestClass
    {
        public A Property { get; set; }
        
        public int Int1 { get; set; }
        public int Int2 { get; set; }

        public override string ToString()
        {
            return "Class CycleDependencyTestClass: { " + Int1 + ", " + Int2 + ", \n" + Property + " }";
        }

        public class A
        {
            public B B { get; set; }
            
            public float Float1 { get; set; }
            public int Int2 { get; set; }
            
            public override string ToString()
            {
                return "Class A: { " + Float1 + ", " + Int2 + ", \n" + B + " }";
            }
        }

        public class B
        {
            public C C { get; set; }
            
            public long Long1 { get; set; }
            public bool Bool1 { get; set; }
            
            public override string ToString()
            {
                return "Class B: { " + Long1 + ", " + Bool1 + ", \n" + C + " }";
            }
        }

        public class C
        {
            public D D { get; set; } 
            
            public DateTime Date1 { get; set; }
            public DateTime Date2 { get; set; }
            
            public override string ToString()
            {
                return "Class C: { " + Date1 + ", " + Date2 + ", \n" + D + " }";
            }
        }
        
        public class D
        {
            private List<A> _a;
            
            public short Short1 { get; set; }
            public string String1 { get; set; }

            public D(List<A> a)
            {
                _a = a;
            }
            
            public override string ToString()
            {
                return "Class D: { " + Short1 + ", " + String1 + ", \n" + _a + " }";
            }
        }
    }
}