using BS.Services.ServiceValidator.Exceptions;
using System;

namespace BS.Services.ServiceValidator
{
    public class ServiceValidator
    {
        public static void IsNull(int? value, string errorMessage)
        {
            if (value == null)
            {
                throw new IdIsNullException(errorMessage);
            }
        }

        public static void IsNull(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new EntityIsNullException(errorMessage);
            }
        }

        public static void IsLessThanOne(int id, string errorMessage)
        {
            if (id < 0)
            {
                throw new IdIsLessThenValidException(errorMessage);
            }
        }

        public static void AreEqual(int id1, int id2, string errorMessage)
        {
            if (id1 != id2)
            {
                throw new CompareTwoIdException(errorMessage);
            }
        }

        public static void IsStringValid(string content, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new StringIsNullOrWhiteSpaceException(errorMessage);
            }
        }
    }
}
