using System;
using System.Runtime.Serialization;

namespace BS.WEB.ControllerValidation.Exceptions
{
    public class AdminRoleLoginException : Exception
    {
        public AdminRoleLoginException()
        {
        }

        public AdminRoleLoginException(string message) : base(message)
        {
        }

        public AdminRoleLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdminRoleLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
