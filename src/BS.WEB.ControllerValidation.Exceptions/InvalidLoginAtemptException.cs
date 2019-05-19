using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.WEB.ControllerValidation.Exceptions
{
    public class InvalidLoginAtemptException : Exception
    {
        public InvalidLoginAtemptException()
        {
        }

        public InvalidLoginAtemptException(string message) : base(message)
        {
        }

        public InvalidLoginAtemptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLoginAtemptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
