using System;

namespace LibUISharp
{
    public interface IControl : IDisposable
    {
        bool Enabled { get; set; }
        bool Visible { get; set; }
        bool TopLevel { get; /*set;*/ }

        void Enable();
        void Disable();
        void Show();
        void Hide();
    }
}