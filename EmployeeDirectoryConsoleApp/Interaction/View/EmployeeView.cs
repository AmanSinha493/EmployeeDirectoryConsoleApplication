using Models;
using Services.Interfaces;
using Employee_Directory_Console_App.Interaction.View.Interfaces;

namespace Employee_Directory_Console_App.Interaction.View
{
    internal class EmployeeView : IEmployeeView
    {
        readonly IRoleServices roleServices;

        public EmployeeView(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }
        public void DisplayEmployee(Employee employee, Role role)
        {
            Console.WriteLine();
            Console.WriteLine($"{employee.Id,-10} | {employee.FName + " " + employee.LName,-20} | {employee.Email,-20} | {role.Location,-13} | {role.Department,-13} | {role.Name,-20} | {employee.JoiningDate,-13} | {employee.Manager,-20} | {employee.Project,-20}");
        }
        public void DisplayList(List<Employee> employeeList)
        {
            Console.WriteLine("\n--------------------------------------------------------------------------- Employees Details ----------------------------------------------------------------------------\n");
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No Record Found");
                return;
            }
            List<Role> roles = roleServices.Get();

            Console.WriteLine($"ID         | NAME                 | EMAIL                | LOCATION      | DEPARTMENT    | ROLE                 | DATE          | MANAGER NAME        | PROJECT NAME         ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Employee employee in employeeList)
            {
                Role role = roleServices.Get(employee!.RoleId!);
                //Role role = roles.FirstOrDefault(r => r.Id == employee.Id)!;
                DisplayEmployee(employee, role);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void DisplayById(Employee employee)
        {
            Role role = roleServices.Get(employee.RoleId!);
            Console.WriteLine("\n------------------------------------------------------------------------------ Employee Detail -----------------------------------------------------------------------------\n");
            Console.WriteLine($"ID         | NAME                 | EMAIL                | LOCATION      | DEPARTMENT    | ROLE                 | DATE          | MANAGER NAME        | PROJECT NAME         ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            DisplayEmployee(employee, role);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
        }
    }
}
