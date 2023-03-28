using WeekendDraw.Components.CsvReader;
using WeekendDraw.MainMenuControls;

namespace WeekendDraw;

public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        var weekendActivities = _csvReader.ProcessWeekendActivity("Resources\\Files\\WeekendActivities.csv");
        var communicationWithUser = new MainMenuFunctions(weekendActivities);

        communicationWithUser.WelcomeUser();

        while (true)
        {
            communicationWithUser.MainMenuDescription();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong choice! Choose DRAW / EDIT / EXIT");
                    Console.ResetColor();
                }
                else if (input.ToLower() == "draw" || input.ToLower() == "edit" || input.ToLower() == "exit")
                {
                    switch (input.ToLower())
                    {
                        case "draw":
                            communicationWithUser.Draw();
                            break;

                        case "edit":
                            communicationWithUser.EditWeekendActivities();
                            break;

                        case "exit":
                            communicationWithUser.ExitProgram();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong choice! Choose DRAW / EDIT / EXIT");
                    Console.ResetColor();
                }
            }
        }
    }
}