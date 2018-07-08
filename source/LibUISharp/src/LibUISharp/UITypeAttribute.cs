using System;

namespace LibUISharp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    internal sealed class UITypeAttribute : Attribute
    {
        public UITypeAttribute(string typeName) => TypeName = typeName;

        public string TypeName { get; }
    }
}