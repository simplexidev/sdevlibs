using System;

namespace LibUISharp.Internal
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = true, AllowMultiple = true)]
    internal sealed class LibuiTypeAttribute : Attribute
    {
        public LibuiTypeAttribute(string name) => Name = name;

        public string Name { get; }
    }
}