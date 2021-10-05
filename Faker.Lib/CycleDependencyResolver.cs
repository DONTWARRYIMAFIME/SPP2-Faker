using System;
using System.Collections.Generic;

namespace Faker
{
    public class CycleDependencyResolver
    {
        private readonly Stack<Type> _stackTypeTrace = new();
        private readonly Stack<Type> _stackSkipTrace = new();

        public bool IsCycleDependencyDetected(Type type)
        {
            if (_stackSkipTrace.TryPeek(out var result))
            {
                if (result == type)
                {
                    return false;
                }
            }

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
        
        public void PushSkipType(Type type)
        {
            _stackTypeTrace.Push(type);
        }
        
        public void PopSkipType()
        {
            _stackTypeTrace.Pop();
        }
        
    }
}