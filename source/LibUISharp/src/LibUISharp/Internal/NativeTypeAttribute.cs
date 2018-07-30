using System;

namespace LibUISharp.Internal
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = true, AllowMultiple = false)]
    internal sealed class NativeTypeAttribute : Attribute
    {
        public NativeTypeAttribute(string name) => Name = name;

        public string Name { get; }
    }
}