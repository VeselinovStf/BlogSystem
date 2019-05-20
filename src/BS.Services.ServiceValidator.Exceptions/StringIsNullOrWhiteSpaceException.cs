using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.Services.ServiceValidator.Exceptions
{
    public class StringIsNullOrWhiteSpaceException : Exception
    {
        public StringIsNullOrWhiteSpaceException()
        {
        }

        public StringIsNullOrWhiteSpaceException(string message) : base(message)
        {
        }

        public StringIsNullOrWhiteSpaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StringIsNullOrWhiteSpaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
