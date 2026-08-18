namespace Yosoku.Core.Extensions;

public static class DateTimeOffsetExtensions
{
    public static DateTimeOffset ToNextSixPm(this DateTimeOffset utcNow)
    {
        var chicagoZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        var nowChicago = TimeZoneInfo.ConvertTime(utcNow, chicagoZone);

        DateTime current = nowChicago.DateTime;

        while (true)
        {
            var target = new DateTime(current.Year, current.Month, current.Day, 18, 0, 0);

            if (target > nowChicago.DateTime &&
                target.DayOfWeek != DayOfWeek.Saturday &&
                target.DayOfWeek != DayOfWeek.Sunday)
            {
                return new DateTimeOffset(target, chicagoZone.GetUtcOffset(target));
            }

            current = current.AddDays(1);
        }
    }
}