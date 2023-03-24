using WeekendDraw.Components.CsvReader.Extensions;
using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<WeekendActivity> ProcessWeekendActivity(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<WeekendActivity>();
            }

            var weekendActivities =
                File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToWeekendActivity();

            return weekendActivities.ToList();
        }
    }
}