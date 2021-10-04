using System;
using System.Collections.Generic;

namespace SPP2_Faker.Faker
{
    public class CycleDependencyResolver
    {
        private readonly Stack<Type> _stackTypeTrace = new();

        public bool IsCycleDependencyDetected(Type type)
        {
            if (_stackTypeTrace.Contains(type))
            {
                Console.WriteLine("[WARN] Cycle dependency detected");
                return true;
            }

            return false;
        }

        public void PushType(Type type)
        {
            _stackTypeTrace.Push(type);
        }

        public void PopType()
        {
            _stackTypeTrace.Pop();
        }
        
    }
}