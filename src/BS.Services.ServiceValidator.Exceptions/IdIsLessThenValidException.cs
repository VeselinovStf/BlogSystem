using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.Services.ServiceValidator.Exceptions
{
    public class IdIsLessThenValidException : Exception
    {
        public IdIsLessThenValidException()
        {
        }

        public IdIsLessThenValidException(string message) : base(message)
        {
        }

        public IdIsLessThenValidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdIsLessThenValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
