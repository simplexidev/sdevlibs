using System;
using System.Runtime.Serialization;

namespace LibUISharp
{
    /// <summary>
    /// Represents UI-related errors.
    /// </summary>
    [Serializable]
    public class UIException : Exception
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
}