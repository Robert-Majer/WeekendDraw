using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.Components.CsvReader.Extensions
{
    public static class SaveToCsvExtension
    {
        private const string fileName = "Resources\\Files\\WeekendActivities.csv";

        public static void SaveToCsv(this List<WeekendActivity> listOfWeekendActivities)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Id,ActivityName,IsSunnyDayNeeded,IsNoCost");

                foreach (var activity in listOfWeekendActivities)
                {
                    writer.WriteLine($"{activity.Id.ToString()}" +
                        $",{activity.Name.ToString()}" +
                        $",{activity.IsSunnyDayNeeded.ToString()}" +
                        $",{activity.IsNoCost.ToString()}");
                }
            }
        }
    }
}