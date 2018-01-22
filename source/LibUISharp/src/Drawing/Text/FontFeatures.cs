using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing.Text
{
    //TODO: Do something with the uiOpenTypeFeaturesForEach thing. Maybe an internal predefined EventHandler?
    public class FontFeatures : IEquatable<FontFeatures>, ICloneable
    {
        public FontFeatures() => Handle = new UIFontFeaturesHandle(uiNewOpenTypeFeatures());

        internal FontFeatures(IntPtr handle) => Handle = new UIFontFeaturesHandle(handle);
        
        protected internal UIFontFeaturesHandle Handle { get; protected set; }

        public FontFeatures Clone() => new FontFeatures(uiOpenTypeFeaturesClone(Handle.DangerousGetHandle()));

        object ICloneable.Clone() => Clone();

        public void Add(string tag, uint value)
        {
            if (tag.Length != 4) throw new ArgumentOutOfRangeException("tag");
            char[] chars = tag.ToCharArray();
            uiOpenTypeFeaturesAdd(Handle.DangerousGetHandle(), Convert.ToByte(chars[0]), Convert.ToByte(chars[1]), Convert.ToByte(chars[2]), Convert.ToByte(chars[3]), value);
        }

        public void Remove(string tag)
        {
            if (tag.Length != 4) throw new ArgumentOutOfRangeException("tag");
            char[] chars = tag.ToCharArray();
            uiOpenTypeFeaturesRemove(Handle.DangerousGetHandle(), Convert.ToByte(chars[0]), Convert.ToByte(chars[1]), Convert.ToByte(chars[2]), Convert.ToByte(chars[3]));
        }

        public bool TryGetFeature(string tag, out uint value)
        {
            if (tag.Length != 4) throw new ArgumentOutOfRangeException("tag");
            char[] chars = tag.ToCharArray();
            return uiOpenTypeFeaturesGet(Handle.DangerousGetHandle(), Convert.ToByte(chars[0]), Convert.ToByte(chars[1]), Convert.ToByte(chars[2]), Convert.ToByte(chars[3]), out value);
        }

        public bool Equals(FontFeatures other) => uiOpenTypeFeaturesEqual(Handle.DangerousGetHandle(), other.Handle.DangerousGetHandle());
    }
}