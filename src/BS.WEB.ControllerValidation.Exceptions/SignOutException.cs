using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.WEB.ControllerValidation.Exceptions
{
    public class SignOutException : Exception
    {
        public SignOutException()
        {
        }

        public SignOutException(string message) : base(message)
        {
        }

        public SignOutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SignOutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
