using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.Services.ServiceValidator.Exceptions
{
    public class CompareTwoIdException : Exception
    {
        public CompareTwoIdException()
        {
        }

        public CompareTwoIdException(string message) : base(message)
        {
        }

        public CompareTwoIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompareTwoIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
