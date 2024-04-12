using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations.Interfaces;
using Validations;
using Models;
using Employee_Directory_Console_App.Interaction.View.Interfaces;
using Employee_Directory_Console_App.Interaction.InputHandler.Interfaces;

namespace Employee_Directory_Console_App.Interaction.InputHandler
{
    internal class EmployeeInputHandler : IEmployeeInputHandler
    {
        readonly IValidation? validator;
        readonly IRoleServices roleServices;
        readonly IEmployeeView view;

        public EmployeeInputHandler(IRoleServices roleServices, IEmployeeView view, IValidation validator)
        {
            this.roleServices = roleServices;
            this.validator = validator;
            this.view = view;
        }
        public void GetDetails(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles)
        {
            bool checkVal = false;
            Console.Write("Enter the first name: ");
            do
            {
                employee.FName = Console.ReadLine();
                checkVal = validator!.CheckValidation(employee.FName!, "name");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the first name again: ");
            } while (!checkVal);

            Console.Write("Enter the last name: ");
            do
            {
                employee.LName = Console.ReadLine();
                checkVal = validator.CheckValidation(employee.LName!, "name");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the last name again: ");
            } while (!checkVal);

            Console.Write("Enter the Email: ");
            do
            {
                employee.Email = Console.ReadLine();
                checkVal = validator.CheckValidation(employee.Email!, "email");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the email again: ");
            } while (!checkVal);

            Console.WriteLine("\n-----------  Available Departments -----------\n");
            int count = 1;

            foreach (var department in departmentRoles)
            {
                Console.WriteLine($"{count++}. {department.Key}");
            }

            Console.WriteLine("\nEnter the Department Choice: ");
            int departmentOption;
            while (!int.TryParse(Console.ReadLine(), out departmentOption) || departmentOption < 1 || departmentOption > departmentRoles.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid department choice: ");
            }

            List<KeyValuePair<string, string>> roles = departmentRoles.ElementAt(departmentOption - 1).Value;

            Console.WriteLine($"\n--------------  Available Roles on {departmentRoles.ElementAt(departmentOption - 1).Key} --------------\n");
            count = 1;
            foreach (var r in roles)
            {
                Console.WriteLine($"{count++}. {r.Key}");
            }

            Console.Write("\nEnter the Role Choice: ");
            int roleOption;
            while (!int.TryParse(Console.ReadLine(), out roleOption) || roleOption < 1 || roleOption > roles.Count)
            {
                Console.Write("Invalid input. Please enter a valid role choice: ");
            }
            employee.RoleId = roles.ElementAt(roleOption - 1).Value;
            Role role = roleServices.Get(employee.RoleId);
            Console.WriteLine($"Location: {role.Location}\n");
            Console.Write("Enter the Date of Birth (format: mm-dd-yyyy): ");
            do
            {
                employee.Dob = Console.ReadLine();
                checkVal = validator.CheckValidation(employee.Dob!, "date");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the date of birth again: ");
            } while (!checkVal);

            Console.Write("Enter the Mobile No.: ");
            do
            {
                employee.MobileNo = Console.ReadLine();
                checkVal = validator.CheckValidation(employee.MobileNo!, "mobile");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the mobile number again: ");
            } while (!checkVal);

            Console.Write("Enter the Joining Date (format: mm-dd-yyyy): ");
            do
            {
                employee.JoiningDate = Console.ReadLine();
                checkVal = validator.CheckValidation(employee.JoiningDate!, "date");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the joining date again: ");
            } while (!checkVal);
            Console.Write("Enter the Manager Name. : ");
            employee.Manager = Console.ReadLine();
            Console.Write("Enter the Project Name : ");
            employee.Project = Console.ReadLine();
        }
        public Employee Add(Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles)
        {
            bool checkVal;
            Employee employee = new();
            Console.Write("Enter the Employee No. : ");
            do
            {
                employee.Id = Console.ReadLine();
                checkVal = validator!.CheckValidation(employee.Id!, "id");
                if (!checkVal)
                    Console.Write("Invalid input. Please enter the Id again: ");
            } while (!checkVal);
            GetDetails(employee, departmentRoles);
            Console.WriteLine("Employee Added Successfully");
            return employee; ;
        }
        public Employee Edit(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles)
        {
            Console.WriteLine("\nSaved Details\n");
            view.DisplayById(employee);
            Console.WriteLine("\nEnter new details\n");
            GetDetails(employee, departmentRoles);
            Console.WriteLine("Employee Updated Successfully");
            return employee;
        }
    }
}
