namespace TRIMANA.Customer.Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime BrazilianTimeZone(this DateTime dateTime)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), timeZoneInfo);
        }
    }
}
