using Foundation;

namespace Optiq.DatePicker.Platforms;

public static class DateExtension
{
    internal static DateTime ReferenceDate = new DateTime(2001, 1, 1, 0, 0, 0);

    public static NSDate? ToNsDate(this DateTime? date)
    {
        if (date == null)
            return null;

        return NSDate.FromTimeIntervalSinceReferenceDate((date.Value - ReferenceDate).TotalSeconds);
    }
}