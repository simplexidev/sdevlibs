using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;
using System;
using System.Runtime.InteropServices;

// uiLabel
namespace LibUISharp
{
    /// <summary>
    /// Represents a standard label, which contains and shows text.
    /// </summary>
    public class Label : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class with the specified text.
        /// </summary>
        /// <param name="text">The specified text for this <see cref="Label"/>.</param>
        public Label(string text)
        {
            IntPtr strPtr = LibuiConvert.ToLibuiString(text);
            Handle = new SafeControlHandle(LibuiLibrary.uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
            this.text = text;
        }

        /// <summary>
        /// Gets or sets this <see cref="Label"/>'s text.
        /// </summary>
        public string Text
        {
            get
            {
                text = LibuiConvert.ToString(LibuiLibrary.uiLabelText(Handle.DangerousGetHandle()));
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = LibuiConvert.ToLibuiString(value);
                    LibuiLibrary.uiLabelSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }
    }
}