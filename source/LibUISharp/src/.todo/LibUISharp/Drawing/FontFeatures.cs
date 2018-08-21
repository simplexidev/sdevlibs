using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    //TODO: Setup the ForEachFunc.
    public class FontFeatures : UIComponent, ICloneable
    {
        private bool disposed = false;

        public FontFeatures()
        {
            Handle = Libui.uiNewOpenTypeFeatures();
            InitializeEvents();
        }

        internal FontFeatures(IntPtr handle)
        {
            Handle = handle;
            InitializeEvents();
        }

        // public event EventHandler ForEachFeature;

        public void Add(char a, char b, char c, char d, long value) => Libui.uiOpenTypeFeaturesAdd(this, a, b, c, d, (uint)value);

        public void Add(string feature, long value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Add(chars[0], chars[1], chars[2], chars[3], value);
        }

        public void Remove(char a, char b, char c, char d) => Libui.uiOpenTypeFeaturesRemove(this, a, b, c, d);

        public void Remove(string feature)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Remove(chars[0], chars[1], chars[2], chars[3]);
        }

        public int TryGetValue(char a, char b, char c, char d, out long value)
        {
            int result = Libui.uiOpenTypeFeaturesGet(this, a, b, c, d, out uint uintValue);
            value = uintValue;
            return result;
        }

        public int TryGetValue(string feature, out long value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            return TryGetValue(chars[0], chars[1], chars[2], chars[3], out value);
        }

        object ICloneable.Clone() => Clone();

        public FontFeatures Clone() => new FontFeatures(Libui.uiOpenTypeFeaturesClone(this));

        // protected override void InitializeEvents() => Libui.uiOpenTypeFeaturesForEach(Handle, (otf, a, b, c, d, value, data) => { OnForEachFeature(EventArgs.Empty); });

        // protected virtual void OnForEachFeature(EventArgs e) => ForEachFeature?.Invoke(this, e);

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.uiFreeOpenTypeFeatures(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}