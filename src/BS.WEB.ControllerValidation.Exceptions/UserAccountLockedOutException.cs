using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BS.WEB.ControllerValidation.Exceptions
{
    public class UserAccountLockedOutException : Exception
    {
        public UserAccountLockedOutException()
        {
        }

        public UserAccountLockedOutException(string message) : base(message)
        {
        }

        public UserAccountLockedOutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAccountLockedOutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
