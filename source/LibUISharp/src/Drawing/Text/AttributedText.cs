using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing.Text
{
    //TODO: Do something with the uiAttributedStringForEach thing. Maybe an internal predefined EventHandler?
    public class AttributedText
    {
        public AttributedText(string text)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            Handle = new UIAttributedTextHandle(uiNewAttributedString(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        public string Text => MarshalHelper.StringFromUTF8(uiAttributedStringString(Handle.DangerousGetHandle()));

        protected internal UIAttributedTextHandle Handle { get; protected set; }

        public virtual UIntPtr Len() => uiAttributedStringLen(Handle.DangerousGetHandle());

        public virtual void Append(string text)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            uiAttributedStringAppendUnattributed(Handle.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        public virtual void InsertAt(string text, UIntPtr at)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            uiAttributedStringInsertAtUnattributed(Handle.DangerousGetHandle(), strPtr, at);
            Marshal.FreeHGlobal(strPtr);
        }

        public virtual void Delete(UIntPtr start, UIntPtr end) => uiAttributedStringDelete(Handle.DangerousGetHandle(), start, end);

        public virtual UIntPtr GraphemeCount() => uiAttributedStringNumGraphemes(Handle.DangerousGetHandle());
        public virtual UIntPtr ByteIndexToGrapheme(UIntPtr pos) => uiAttributedStringByteIndexToGrapheme(Handle.DangerousGetHandle(), pos);
        public virtual UIntPtr GraphemeToByteIndex(UIntPtr pos) => uiAttributedStringGraphemeToByteIndex(Handle.DangerousGetHandle(), pos);

        public virtual void SetAttribute(AttributeOptions spec, UIntPtr start, UIntPtr end) => uiAttributedStringSetAttribute(Handle.DangerousGetHandle(), spec.Internal, start, end);
    }

    public class AttributeOptions
    {
        public AttributeOptions(TextAttribute type, string family, UIntPtr value, double dbl, Color color, FontFeatures features)
        {
            Type = type;
            Family = family;
            Value = value;
            Double = dbl;
            Color = color;
            Features = features;
        }

        internal uiAttributeSpec Internal = new uiAttributeSpec();

        public TextAttribute Type
        {
            get => Internal.Type;
            set => Internal.Type = value;
        }

        public string Family
        {
            get => MarshalHelper.StringFromUTF8(Internal.Family);
            set
            {
                IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                Internal.Family = strPtr;
                Marshal.FreeHGlobal(strPtr);
            }
        }

        public UIntPtr Value
        {
            get => Internal.Value;
            set => Internal.Value = value;
        }

        public double Double
        {
            get => Internal.Double;
            set => Internal.Double = value;
        }

        public Color Color
        {
            get => new Color(Internal.R, Internal.G, Internal.B, Internal.A);
            set
            {
                Internal.R = value.R;
                Internal.G = value.G;
                Internal.B = value.B;
                Internal.A = value.A;
            }
        }

        public FontFeatures Features
        {
            get => new FontFeatures(Internal.Features);
            set => Internal.Features = value.Handle.DangerousGetHandle();
        }
    }
}