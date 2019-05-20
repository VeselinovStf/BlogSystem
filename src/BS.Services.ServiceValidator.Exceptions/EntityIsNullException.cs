using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.Services.ServiceValidator.Exceptions
{
    public class EntityIsNullException : Exception
    {
        public EntityIsNullException()
        {
        }

        public EntityIsNullException(string message) : base(message)
        {
        }

        public EntityIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
