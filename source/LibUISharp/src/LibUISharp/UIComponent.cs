using System;

namespace LibUISharp
{
    public abstract class UIComponent : IDisposable
    {
        protected UIComponent() { }

        protected virtual void InitializeComponent() { }
        protected virtual void InitializeEvents() { }

        public abstract void Dispose();
        protected abstract void Dispose(bool disposing);
    }
}