using CommandLine;
using Employee_Directory_Console_App.ServiceHandler.Interfaces;
using Models;
using EmployeeDirectory.Models;
using Employee_Directory_Console_App.Interaction.View.Menu;

namespace Employee_Directory_Console_App.ServiceHandler
{
    internal class MainMenuHandler
    {
        IServiceHandler<Employee> empHandler ;
        IServiceHandler<Role> roleHandler;
        public MainMenuHandler(IServiceHandler<Employee> empHandler, IServiceHandler<Role> roleHandler)
        {
            this.empHandler = empHandler;
            this.roleHandler = roleHandler;
        }
        public void HandleCommands()

        {
            var parser = new Parser(settings =>
            {
                settings.EnableDashDash = false;
            });

            bool loopContinue = true;
            do
            {
                new MainMenu().DisplayMenu();
                Console.Write("Enter command: ");
                string? command = Console.ReadLine();

                var result = parser.ParseArguments<Commands>(new[] { "--command", command });
                result.WithParsed(options =>
                {
                    if (options.Command == 1)
                    {
                        new EmployeesMenu().DisplayMenu();
                        empHandler.HandleServices();
                    }
                    else if (options.Command == 2)
                    {
                        new RolesMenu().DisplayMenu();
                        roleHandler.HandleServices();
                    }
                    else if (options.Command == 3)
                    {
                        loopContinue = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Please enter a valid command number.");
                    }
                });
            } while (loopContinue);
        }
    }
}
