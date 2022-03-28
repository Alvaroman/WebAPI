using FooBar.Domain.Exception;

namespace FooBar.Domain.Exception
{
    public class FullCapacityException : AppException
    {
        public FullCapacityException() { }
        public FullCapacityException(string message) : base(message) { }
        public FullCapacityException(string message, System.Exception inner) : base(message, inner) { }
        protected FullCapacityException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
