using System;

namespace Rozdzial7_5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public static string? CompositeFormatDate(object input, string compositFormaString) =>
        input switch
        {
            DateTime { Year: int year, Month: int month, Day: int day } => (year, month, day),
            DateTimeOffset { Year: int year, Month: int month, Day: int day } => (year, month, day),
            string dateText => DateTime.TryParse(dateText, out DateTime dateTime) ? (dateTime.Year, dateTime.Month, dateTime.Day) : default((int Year, int Month, int Day)?),
            _ => null
        } is { } date ? string.Format(compositFormaString, date.Year, date.Month, date.Day) : null;
    }
}