using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    public abstract class UIHandle : SafeHandle
    {
        public UIHandle() : base(IntPtr.Zero, true) { }
        public UIHandle(IntPtr ptr) : base(ptr, true) { }
        public UIHandle(UIHandle safeHandle) : base(safeHandle.DangerousGetHandle(), true) { }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected abstract override bool ReleaseHandle();
    }

    public sealed class UIControlHandle : UIHandle
    {
        public UIControlHandle() : base() { }
        public UIControlHandle(IntPtr intPtr) : base(intPtr) { }
        public UIControlHandle(UIHandle safeHandle) : base(safeHandle.DangerousGetHandle()) { }

        internal UIntPtr uhandle => UI.uiControlHandle(handle);

        public UIntPtr DangerousGetUHandle() => uhandle;

        protected override bool ReleaseHandle()
        {
            UI.uiControlDestroy(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }

    public class UIDrawHandle : UIHandle
    {
        public UIDrawHandle() : base() { }
        public UIDrawHandle(IntPtr intPtr) : base(intPtr) { }
        public UIDrawHandle(UIHandle safeHandle) : base(safeHandle.DangerousGetHandle()) { }

        protected override bool ReleaseHandle()
        {
            handle = IntPtr.Zero;
            return true;
        }
    }

    public sealed class UIPathHandle : UIHandle
    {
        public UIPathHandle() : base() { }
        public UIPathHandle(IntPtr intPtr) : base(intPtr) { }
        public UIPathHandle(UIHandle safeHandle) : base(safeHandle) { }

        protected override bool ReleaseHandle()
        {
            UI.uiDrawFreePath(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }

    public sealed class UIFontFeaturesHandle : UIHandle
    {
        public UIFontFeaturesHandle() : base(IntPtr.Zero) { }
        public UIFontFeaturesHandle(IntPtr intPtr) : base(intPtr) { }

        protected override bool ReleaseHandle()
        {
            UI.uiFreeOpenTypeFeatures(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }

    public sealed class UIAttributedTextHandle : UIHandle
    {
        public UIAttributedTextHandle() : base(IntPtr.Zero) { }
        public UIAttributedTextHandle(IntPtr intPtr) : base(intPtr) { }

        protected override bool ReleaseHandle()
        {
            UI.uiFreeAttributedString(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }

    public sealed class TextLayoutSafeHandle : UIHandle
    {
        public TextLayoutSafeHandle() : base(IntPtr.Zero) { }
        public TextLayoutSafeHandle(IntPtr intPtr) : base(intPtr) { }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            UI.uiDrawFreeTextLayout(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }
}