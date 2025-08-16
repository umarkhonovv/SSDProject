using System.Runtime.Serialization;

namespace WebApiA.Exceptions
{
    [Serializable]
    public class ValidationException : Exceptions
    {
        public ValidationException() { }
        public ValidationException(String message) : base(message) { }
        public ValidationException(String message, Exception inner) : base(message, inner) { }
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
