using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// The basic exception type for all UI-related exception.
    /// </summary>
    [Serializable]
    public class UIException : ExternalException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIException"/> class.
        /// </summary>
        public UIException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The error message that specifies the reason for the exception.</param>
        public UIException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIException"/> class with the specified error message
        /// and <see langword="abstract"/>reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that specifies the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public UIException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected UIException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }

    /// <summary>
    /// The exception that is thrown when a <see cref="UIComponent{T}"/> object's handle is null or invalid.
    /// </summary>
    [Serializable]
    public class UIHandleInvalidException<T> : UIException
        where T : SafeHandleZeroIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIHandleInvalidException"/> class.
        /// </summary>
        public UIHandleInvalidException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHandleInvalidException"/> class with the specified error message.
        /// </summary>
        /// <param name="component">The component whose handle is invalid.</param>
        public UIHandleInvalidException(UIComponent<T> component) : base() => Component = component;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHandleInvalidException"/> class with the specified error message.
        /// </summary>
        /// <param name="component">The component whose handle is invalid.</param>
        /// <param name="message">The error message that specifies the reason for the exception.</param>
        public UIHandleInvalidException(UIComponent<T> component, string message) : base(message) => Component = component;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHandleInvalidException"/> class with the specified error message
        /// and <see langword="abstract"/>reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="component">The component whose handle is invalid.</param>
        /// <param name="message">The error message that specifies the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public UIHandleInvalidException(UIComponent<T> component, string message, Exception inner) : base(message, inner) => Component = component;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHandleInvalidException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected UIHandleInvalidException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }

        public UIComponent<T> Component { get; }

        public string NativeType
        {
            get
            {
                NativeTypeAttribute attr = (NativeTypeAttribute)Attribute.GetCustomAttribute(Component.GetType(), typeof(NativeTypeAttribute));
                return attr.Name;
            }
        }
    }
}