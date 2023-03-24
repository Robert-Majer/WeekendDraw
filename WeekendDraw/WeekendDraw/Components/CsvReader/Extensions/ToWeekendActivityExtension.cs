using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.Components.CsvReader.Extensions
{
    public static class ToWeekendActivityExtension
    {
        public static IEnumerable<WeekendActivity> ToWeekendActivity(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new WeekendActivity
                {
                    Id = int.Parse(columns[0]),
                    Name = columns[1],
                    IsSunnyDayNeeded = bool.Parse(columns[2]),
                    IsNoCost = bool.Parse(columns[3]),
                };
            }
        }
    }
}