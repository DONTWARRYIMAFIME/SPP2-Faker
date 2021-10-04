using System;

namespace Generator.SDK
{
    public interface ICollectionGenerator
    {
        Type Type { get; }
        object Generate(Type type, Func<Type, object> method);
    }
}