using DateTimeWrapper.Abstract;
using System;

namespace DateTimeProvider
{
    public class ExactDateTimeNowProvider : IDateTimeWrapper
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
