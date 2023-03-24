using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.Components.CsvReader
{
    public interface ICsvReader
    {
        List<WeekendActivity> ProcessWeekendActivity(string filePath);
    }
}