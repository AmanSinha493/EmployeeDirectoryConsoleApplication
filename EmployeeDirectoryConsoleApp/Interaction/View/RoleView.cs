using Models;
using Validations.Interfaces;
using Validations;
using Services.Interfaces;
using Employee_Directory_Console_App.Interaction.View.Interfaces;

namespace Employee_Directory_Console_App.Interaction.View
{
    internal class RoleView : IRoleView
    {
        readonly IEmployeeServices empServices;

        public RoleView(IEmployeeServices employeeServices)
        {
            empServices = employeeServices;
        }
        public List<string> AssignEmployees()
        {
            Console.WriteLine("Do you Want to assign Employees to this role (y/n)");
            string assignEmployees = Console.ReadLine();
            List<string> employees = new List<string>();
            if (assignEmployees == "y")
            {
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine("Enter Employee Id");
                string id = Console.ReadLine();
                while (id != "0")
                {
                    if (empServices.CheckEmployee(id))
                    {
                        employees.Add(id);
                        Console.WriteLine("Employee Assigned");
                    }
                    else
                    {
                        Console.WriteLine($"{id} does not exist");
                    }
                    Console.WriteLine("Enter Employee Id");
                    id = Console.ReadLine();
                }
            }
            return employees;
        }
        public void DisplayList(List<Role> roleList)
        {
            Console.WriteLine("\n----------------------------- Roles Details ---------------------------\n");
            if (roleList.Count == 0)
            {
                Console.WriteLine("No Record Found");
                return;
            }
            Console.WriteLine($"| NAME                         | LOCATION      | DEPARTMENT    |");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (Role role in roleList)
                DisplayRole(role);
            Console.WriteLine("-------------------------------------------------------------------");
        }
        public void DisplayRole(Role role)
        {
            Console.WriteLine($"{role.Name,-30} | {role.Location,-13} | {role.Department,-13} |");
        }


    }
}
