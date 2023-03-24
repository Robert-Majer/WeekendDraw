using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.Components.CsvReader.Extensions
{
    public static class WriteAllWeekendActivitesExtension
    {
        public static void WriteAllWeekendActivites(this List<WeekendActivity> listOfWeekendActivities)
        {
            Console.WriteLine("LIST OF ALL WEEKEND ACTIVITIES:");
            Console.WriteLine();

            foreach (var weekendActivity in listOfWeekendActivities)
            {
                Console.WriteLine($"Id: {weekendActivity.Id}");
                Console.WriteLine($"Name activity: {weekendActivity.Name}");
                Console.WriteLine($"Is sunny day needed: {weekendActivity.IsSunnyDayNeeded}");
                Console.WriteLine($"Is no cost: {weekendActivity.IsNoCost}");
                Console.WriteLine();
            }
        }
    }
}