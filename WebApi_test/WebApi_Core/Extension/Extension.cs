using System;

namespace WebApi_Core.Extension
{
    public static class Extension
    {
        public static bool isValidDate(this string stringDate)
        {
            if (stringDate.Length is 0)
                return false;

            DateTime.TryParse(stringDate, out DateTime date);

            // If date result is min value, then conversion fails and its not a date.
            if (date.CompareTo(DateTime.MinValue) is 0)
                return false;
            else
                return true;
        }
    }
}
