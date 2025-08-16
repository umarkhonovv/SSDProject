using System.Runtime.Serialization;

namespace WebApiA.Exceptions
{
    [Serializable]
    public class Exceptions : Exception
    {
        public Exceptions() { }

        public Exceptions(string message) : base(message) { }

        public Exceptions(string message, Exception inner) : base(message, inner) { }

        protected Exceptions(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
