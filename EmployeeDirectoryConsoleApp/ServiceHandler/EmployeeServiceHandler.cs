using CommandLine;
using Employee_Directory_Console_App.ServiceHandler.Interfaces;
using Services.Interfaces;
using Models;
using Services;
using EmployeeDirectory.Models;
using Employee_Directory_Console_App.Interaction.View.Interfaces;
using Employee_Directory_Console_App.Interaction.InputHandler.Interfaces;


namespace Employee_Directory_Console_App.ServiceHandler
{
    internal class EmployeeServiceHandler : IServiceHandler<Employee>
    {
        Parser parser = new Parser(settings =>
        {
            settings.EnableDashDash = false;
        });

        IEmployeeServices employeeServices;
        IRoleServices roleServices;
        IEmployeeView view;
        IEmployeeInputHandler inputHandler;
        public EmployeeServiceHandler(IEmployeeServices employeeServices, IRoleServices roleServices, IEmployeeView view,IEmployeeInputHandler inputHandler)
        {
            this.employeeServices = employeeServices;
            this.roleServices = roleServices;
            this.view = view;
            this.inputHandler = inputHandler;
        }
        public void HandleServices()
        {
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
                        Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles = roleServices.GetDepartmentRoles();
                        Employee employee = inputHandler.Add(departmentRoles);
                        employeeServices?.Add(employee);
                    }
                    else if (options.Command == 5)
                    {
                        string id;
                        bool flag = false;
                        Console.Write("Enter Employee no.");
                        do
                        {
                            id = Console.ReadLine()!;
                            List<string> employees = employeeServices!.GetEmployeeIds();
                            flag = employees.Any(e => e == id);
                            if (!flag)
                                Console.Write("Employee no does not exist, please enter valid employee no : ");
                        } while (!flag);
                        employeeServices.Delete(id);
                        Console.WriteLine(id + " employee deleted successfully");
                    }
                    else if (options.Command == 4)
                    {
                        string id;
                        bool flag = false;
                        Console.Write("Enter Employee no.");
                        do
                        {
                            id = Console.ReadLine()!;
                            List<string> employees = employeeServices!.GetEmployeeIds();
                            flag = employees.Any(e => e == id);
                            if (!flag)
                                Console.Write("Employee no does not exist, please enter valid employee no : ");
                        } while (!flag);
                        Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles = roleServices.GetDepartmentRoles();
                        Employee employee = employeeServices.Get(id);
                        employeeServices.Edit(inputHandler.Edit(employee, departmentRoles));
                    }
                    else if (options.Command == 3)
                    {
                        string id;
                        bool flag = false;
                        Console.Write("Enter Employee no.");
                        do
                        {
                            id = Console.ReadLine();
                            List<string> employees = employeeServices!.GetEmployeeIds();
                            flag = employees.Any(e => e == id);
                            if (!flag)
                                Console.Write("Employee no does not exist, please enter valid employee no : ");
                        } while (!flag);
                        Employee employee = employeeServices.Get(id);
                        view.DisplayById(employee);
                    }
                    else if (options.Command == 2)
                    {
                        List<Employee> employeeList = employeeServices.Get();
                        view.DisplayList(employeeList);
                    }
                    else if (options.Command == 6)
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
