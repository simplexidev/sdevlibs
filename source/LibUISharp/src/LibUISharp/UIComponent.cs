using LibUISharp.SafeHandles;
using System;

namespace LibUISharp
{
    /// <summary>
    /// The base implementation for a Libui component.
    /// </summary>
    public interface IUIComponent : IDisposable { }

    /// <summary>
    /// The base implementation for a Libui component.
    /// </summary>
    public abstract class UIComponent
    {
        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected virtual void InitializeComponent() { }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected virtual void InitializeEvents() { }
    }
    
    /// <summary>
    /// The base implementation for a UI component with the specified type of <see cref="SafeHandleZeroIsInvalid"/> as the handle.
    /// </summary>
    /// <typeparam name="T">The type of safe handle.</typeparam>
    public abstract class UIComponent<T> : UIComponent
        where T : SafeHandleZeroIsInvalid
    {
        /// <summary>
        /// Gets this component's native handle in the form of a <see cref="SafeHandleZeroIsInvalid"/>.
        /// </summary>
        internal protected T Handle { get; private protected set; }
    }
}