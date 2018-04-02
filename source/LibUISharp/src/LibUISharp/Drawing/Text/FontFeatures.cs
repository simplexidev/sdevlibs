using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing.Text
{
    // uiOpenTypeFeatures
    //TODO: Setup the ForEachFunc. Not sure how to do that yet.
    public class FontFeatures : UIComponent, ICloneable
    {
        private bool disposed = false;

        public FontFeatures()
        {
            Handle = uiNewOpenTypeFeatures();
            InitializeEvents();
        }

        internal FontFeatures(FontFeaturesSafeHandle safeHandle)
        {
            Handle = safeHandle;
            InitializeEvents();
        }

        //TODO: public event EventHandler ForEachFeature;

        internal FontFeaturesSafeHandle Handle { get; set; }

        public void Add(byte a, byte b, byte c, byte d, uint value) => uiOpenTypeFeaturesAdd(Handle, a, b, c, d, value);

        public void Add(char a, char b, char c, char d, uint value) => Add((byte)a, (byte)b, (byte)c, (byte)d, value);

        public void Add(string feature, uint value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Add(chars[0], chars[1], chars[2], chars[3], value);
        }

        public void Remove(byte a, byte b, byte c, byte d) => uiOpenTypeFeaturesRemove(Handle, a, b, c, d);

        public void Remove(char a, char b, char c, char d) => Remove((byte)a, (byte)b, (byte)c, (byte)d);

        public void Remove(string feature)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Remove(chars[0], chars[1], chars[2], chars[3]);
        }

        public int TryGetValue(byte a, byte b, byte c, byte d, out uint value) => uiOpenTypeFeaturesGet(Handle, a, b, c, d, out value);

        public int TryGetValue(char a, char b, char c, char d, out uint value) => TryGetValue((byte)a, (byte)b, (byte)c, (byte)d, out value);

        public int TryGetValue(string feature, out uint value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            return TryGetValue(chars[0], chars[1], chars[2], chars[3], out value);
        }

        //TODO: protected virtual void OnForEachFeature(EventArgs e) => ForEachFeature?.Invoke(this, e);

        object ICloneable.Clone() => Clone();

        public FontFeatures Clone() => new FontFeatures(uiOpenTypeFeaturesClone(Handle));

        protected override void InitializeEvents()
        {
            //TODO: uiOpenTypeFeaturesForEach(Handle, (otf, a, b, c, d, value, data) => { OnForEachFeature(EventArgs.Empty); });
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    if (!Handle.IsInvalid)
                        Handle.Dispose();
                disposed = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}