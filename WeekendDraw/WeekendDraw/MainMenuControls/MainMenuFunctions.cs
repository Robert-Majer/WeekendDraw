using System.Diagnostics;
using WeekendDraw.Components.CsvReader.Extensions;
using WeekendDraw.Components.CsvReader.Models;

namespace WeekendDraw.MainMenuControls
{
    public class MainMenuFunctions : IMainMenuFunctions
    {
        private static MainMenuFunctions _instance = null;

        private readonly List<WeekendActivity> _weekendActivities;

        private MainMenuFunctions(List<WeekendActivity> weekendActivities)
        {
            _weekendActivities = weekendActivities;
        }

        public static MainMenuFunctions GetInstance(List<WeekendActivity> weekendActivities)
        {
            if (_instance == null)
            {
                _instance = new MainMenuFunctions(weekendActivities);
            }

            return _instance;
        }

        public void Draw()
        {
            var drawActivitiesList = _weekendActivities;

            Console.WriteLine();
            Console.WriteLine("Will the weather be nice this weekend? [Yes/No]");
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose yes or no!");
                    Console.ResetColor();
                }
                else if (input.ToLower() == "yes" || input.ToLower() == "no")
                {
                    switch (input.ToLower())
                    {
                        case "yes":
                            drawActivitiesList = drawActivitiesList.Where(x => x.IsSunnyDayNeeded == true).ToList();
                            break;

                        case "no":
                            drawActivitiesList = drawActivitiesList.Where(x => x.IsSunnyDayNeeded == false).ToList();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose yes or no!");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Will the activity be free? [Yes/No]");
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose yes or no!");
                    Console.ResetColor();
                }
                else if (input.ToLower() == "yes" || input.ToLower() == "no")
                {
                    switch (input.ToLower())
                    {
                        case "yes":
                            drawActivitiesList = drawActivitiesList.Where(x => x.IsNoCost == true).ToList();
                            break;

                        case "no":
                            drawActivitiesList = drawActivitiesList.Where(x => x.IsNoCost == false).ToList();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose yes or no!");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            var random = new Random();
            var randomIndex = random.Next(0, drawActivitiesList.Count);
            var drawActivity = drawActivitiesList[randomIndex].Name.ToString();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ---==== Drawn activity: " + drawActivity.ToUpper() + " ====---");
            Console.WriteLine("  ---==== Have a nice weekend! :)  ====---");
            Console.ResetColor();
        }

        public void EditWeekendActivities()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("         --== EDIT ==--  ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("[SHOW] - show all weekend activities");
            Console.WriteLine("[ADD] - add new activity");
            Console.WriteLine("[DELETE] - delete activity from list");
            Console.WriteLine("[SAVE] - save list to file CSV");
            Console.WriteLine("[MENU] - back to Main Menu");

            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong choice! Choose SHOW / ADD / DELETE / MENU");
                    Console.ResetColor();
                }
                else if (input.ToLower() == "show" || input.ToLower() == "add" || input.ToLower() == "delete" || input.ToLower() == "menu" || input.ToLower() == "save")
                {
                    switch (input.ToLower())
                    {
                        case "show":
                            Console.WriteLine();
                            _weekendActivities.WriteAllWeekendActivites();
                            break;

                        case "add":
                            Console.WriteLine();
                            Console.WriteLine("Name new activity [at least 4 letters]");

                            var newActivity = new WeekendActivity();
                            var lastIdFromList = _weekendActivities.Last().Id;
                            newActivity.Id = lastIdFromList + 1;

                            while (true)
                            {
                                var inputAdd = Console.ReadLine();

                                if (inputAdd == null || inputAdd.Length < 4)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong name [at least 4 letters]");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    newActivity.Name = inputAdd;
                                    Console.WriteLine($"New activity name is: {newActivity.Name}");
                                    break;
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("Activity require nice weather? [Yes/No]");
                            while (true)
                            {
                                var inputAdd = Console.ReadLine();

                                if (inputAdd == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choose yes or no!");
                                    Console.ResetColor();
                                }
                                else if (inputAdd.ToLower() == "yes" || inputAdd.ToLower() == "no")
                                {
                                    switch (inputAdd.ToLower())
                                    {
                                        case "yes":
                                            newActivity.IsSunnyDayNeeded = true;
                                            break;

                                        case "no":
                                            newActivity.IsSunnyDayNeeded = false;
                                            break;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choose yes or no!");
                                    Console.ResetColor();
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("Activity is free? [Yes/No]");
                            while (true)
                            {
                                var inputAdd = Console.ReadLine();

                                if (inputAdd == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choose yes or no!");
                                    Console.ResetColor();
                                }
                                else if (inputAdd.ToLower() == "yes" || inputAdd.ToLower() == "no")
                                {
                                    switch (inputAdd.ToLower())
                                    {
                                        case "yes":
                                            newActivity.IsNoCost = true;
                                            break;

                                        case "no":
                                            newActivity.IsNoCost = false;
                                            break;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choose yes or no!");
                                    Console.ResetColor();
                                }
                            }

                            _weekendActivities.Add(newActivity);

                            Console.WriteLine();
                            Console.WriteLine("New activity has been created");
                            Console.WriteLine($"New activity ID: {newActivity.Id}");
                            Console.WriteLine($"New activity name: {newActivity.Name}");
                            Console.WriteLine($"Is sunny day needed: {newActivity.IsSunnyDayNeeded}");
                            Console.WriteLine($"Is no cost: {newActivity.IsNoCost}");
                            break;

                        case "delete":
                            Console.WriteLine();
                            Console.WriteLine("Enter the activity ID number or exit [EXIT]");
                            while (true)
                            {
                                var inputDelete = Console.ReadLine();
                                var isIntiger = int.TryParse(inputDelete, out int inputToInteger);

                                if (inputDelete?.ToLower() == "exit") { break; }
                                else if (inputDelete == null || isIntiger == false)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ID must be integer");
                                    Console.ResetColor();
                                }
                                else if (!_weekendActivities.Any(x => x.Id == inputToInteger))
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ID not listed");
                                    Console.ResetColor();
                                }
                                else if (_weekendActivities.Any(x => x.Id == inputToInteger))
                                {
                                    var activityToRemove = _weekendActivities.First(x => x.Id == inputToInteger);
                                    _weekendActivities.Remove(activityToRemove);
                                    Console.WriteLine();
                                    Console.WriteLine("Deleted activity with ID " + inputToInteger);
                                    break;
                                }
                            }
                            break;

                        case "save":
                            _weekendActivities.SaveToCsv();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("List has been saved");
                            Console.ResetColor();
                            break;

                        case "menu":
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong choice! Choose SHOW / ADD / DELETE / MENU");
                    Console.ResetColor();
                }
            }
        }

        public void ExitProgram()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nPress any key to leave.");
            Console.ResetColor();
            Environment.Exit(0);
        }

        public void WelcomeUser()
        {
            Console.WriteLine("Welcome to WeekendDraw application.");
            Console.WriteLine();
            Console.WriteLine("The application is used to draw an idea for the upcoming weekend.");
            Console.WriteLine("It is intended to reduce the need to make decisions during the week, which is already too heavy.. :)");
            Console.WriteLine("Have a nice weekend! :)");
            Console.WriteLine();
            Console.WriteLine("====================================================================================================");
        }

        public void MainMenuDescription()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("         --== MAIN MENU ==--  ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("[DARW] - draw your activity for a weekend");
            Console.WriteLine("[EDIT] - edit your list of weekend activities");
            Console.WriteLine("[EXIT] - close the program");
        }
    }
}