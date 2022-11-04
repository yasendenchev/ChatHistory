namespace ChatHistory.Domain.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetDateTimeWithRoundedHour(DateTime timeStamp)
        {
            return new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, 0, 0);
        }
    }
}
