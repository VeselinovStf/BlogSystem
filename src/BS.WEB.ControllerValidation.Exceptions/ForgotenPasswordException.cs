using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.WEB.ControllerValidation.Exceptions
{
    public class ForgotenPasswordException : Exception
    {
        public ForgotenPasswordException()
        {
        }

        public ForgotenPasswordException(string message) : base(message)
        {
        }

        public ForgotenPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ForgotenPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
