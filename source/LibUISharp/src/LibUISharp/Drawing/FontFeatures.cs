using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiOpenTypeFeatures
namespace LibUISharp.Drawing
{
    //TODO: Setup the ForEachFunc. Not sure how to do that yet.
    public class FontFeatures : UIComponent<SafeFontFeaturesHandle>, IUIComponent, ICloneable
    {
        private bool disposed = false;

        public FontFeatures()
        {
            Handle = new SafeFontFeaturesHandle(LibuiLibrary.uiNewOpenTypeFeatures());
            InitializeEvents();
        }

        internal FontFeatures(SafeFontFeaturesHandle safeHandle)
        {
            Handle = safeHandle;
            InitializeEvents();
        }

        //TODO: public event EventHandler ForEachFeature;

        public void Add(byte a, byte b, byte c, byte d, long value) => LibuiLibrary.uiOpenTypeFeaturesAdd(Handle.DangerousGetHandle(), a, b, c, d, (uint)value);

        public void Add(char a, char b, char c, char d, long value) => Add((byte)a, (byte)b, (byte)c, (byte)d, value);

        public void Add(string feature, long value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Add(chars[0], chars[1], chars[2], chars[3], value);
        }

        public void Remove(byte a, byte b, byte c, byte d) => LibuiLibrary.uiOpenTypeFeaturesRemove(Handle.DangerousGetHandle(), a, b, c, d);

        public void Remove(char a, char b, char c, char d) => Remove((byte)a, (byte)b, (byte)c, (byte)d);

        public void Remove(string feature)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            Remove(chars[0], chars[1], chars[2], chars[3]);
        }

        public int TryGetValue(byte a, byte b, byte c, byte d, out long value)
        {
            var result = LibuiLibrary.uiOpenTypeFeaturesGet(Handle.DangerousGetHandle(), a, b, c, d, out uint uintValue);
            value = uintValue;
            return result;
        }

        public int TryGetValue(char a, char b, char c, char d, out long value) => TryGetValue((byte)a, (byte)b, (byte)c, (byte)d, out value);

        public int TryGetValue(string feature, out long value)
        {
            if (feature.Length > 4 || feature.Length < 4)
                throw new ArgumentException("feature");

            char[] chars = feature.ToCharArray();
            return TryGetValue(chars[0], chars[1], chars[2], chars[3], out value);
        }

        //TODO: protected virtual void OnForEachFeature(EventArgs e) => ForEachFeature?.Invoke(this, e);

        object ICloneable.Clone() => Clone();

        public FontFeatures Clone() => new FontFeatures(new SafeFontFeaturesHandle(LibuiLibrary.uiOpenTypeFeaturesClone(Handle.DangerousGetHandle())));

        protected override void InitializeEvents()
        {
            //TODO: uiOpenTypeFeaturesForEach(Handle, (otf, a, b, c, d, value, data) => { OnForEachFeature(EventArgs.Empty); });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    if (!Handle.IsInvalid)
                        Handle.Dispose();
                disposed = true;
            }
        }
    }
}