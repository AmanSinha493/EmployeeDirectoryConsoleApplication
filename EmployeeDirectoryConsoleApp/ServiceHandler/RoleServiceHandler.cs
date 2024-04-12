using CommandLine;
using Employee_Directory_Console_App.Interaction.InputHandler.Interfaces;
using Employee_Directory_Console_App.Interaction.View.Interfaces;
using Employee_Directory_Console_App.ServiceHandler.Interfaces;
using EmployeeDirectory.Models;
using Models;
using Services.Interfaces;

namespace Employee_Directory_Console_App.ServiceHandler
{
    internal class RoleServiceHandler : IServiceHandler<Role>
    {
        readonly IRoleView view;
        readonly IRoleServices? roleService;
        readonly IRoleInputHandler inputHandler;
        public RoleServiceHandler(IRoleServices roleService, IRoleView view, IRoleInputHandler inputHandler)
        {
            this.roleService = roleService;
            this.view = view;
            this.inputHandler = inputHandler;
        }
        public void HandleServices()
        {
            var parser = new Parser(settings =>
            {
                settings.EnableDashDash = false;
            });
            bool loopContinue = true;
            do
            {
                Console.Write("Enter command: ");
                string? command = Console.ReadLine();
                var result = parser.ParseArguments<Commands>(new[] { "--command", command });
                result.WithParsed(options =>
                {
                    if (options.Command == 1)
                    {
                        Role role = inputHandler.Add();
                        List<string> employeeToAssign = view.AssignEmployees();
                        roleService!.Add(role, employeeToAssign);
                    }
                    else if (options.Command == 2)
                    {
                        view.DisplayList(roleService!.Get());
                    }
                    else if (options.Command == 3)
                    {
                        loopContinue = false;
                    }
                    else
                    {
                        Console.WriteLine("No valid command-line options provided.");
                    }
                });
            } while (loopContinue);
        }


    }
}
