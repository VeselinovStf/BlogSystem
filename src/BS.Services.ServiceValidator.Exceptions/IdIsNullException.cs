using System;
using System.Runtime.Serialization;

namespace BS.Services.ServiceValidator.Exceptions
{
    public class IdIsNullException : Exception
    {
        public IdIsNullException()
        {
        }

        public IdIsNullException(string message) : base(message)
        {
        }

        public IdIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
