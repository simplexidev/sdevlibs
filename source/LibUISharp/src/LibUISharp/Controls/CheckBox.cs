using System;
using System.Runtime.InteropServices;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiCheckbox
namespace LibUISharp.Controls
{
    public class CheckBox : Control
    {
        private string text;
        private bool @checked;

        public CheckBox(string text)
        {
            IntPtr strPtr = LibuiLibrary.UTF8Helper.ToUTF8Ptr(text);
            Handle = new SafeControlHandle(LibuiLibrary.uiNewCheckbox(strPtr));
            Marshal.FreeHGlobal(strPtr);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler Toggled;
        
        public string Text
        {
            get
            {
                text = LibuiLibrary.UTF8Helper.ToUTF16Str(LibuiLibrary.uiCheckboxText(Handle.DangerousGetHandle()));
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = LibuiLibrary.UTF8Helper.ToUTF8Ptr(value);
                    LibuiLibrary.uiCheckboxSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        public bool Checked
        {
            get
            {
                @checked = LibuiLibrary.uiCheckboxChecked(Handle.DangerousGetHandle());
                return @checked;
            }
            set
            {
                if (@checked != value)
                {
                    LibuiLibrary.uiCheckboxSetChecked(Handle.DangerousGetHandle(), value);
                    @checked = value;
                }
            }
        }

        protected sealed override void InitializeEvents() => LibuiLibrary.uiCheckboxOnToggled(Handle.DangerousGetHandle(), (checkbox, data) => { OnToggled(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnToggled(EventArgs e) => Toggled?.Invoke(this, e);
    }
}