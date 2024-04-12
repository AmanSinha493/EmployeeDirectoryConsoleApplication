using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations.Interfaces;
using Validations;
using Employee_Directory_Console_App.Interaction.InputHandler.Interfaces;

namespace Employee_Directory_Console_App.Interaction.InputHandler
{
    internal class RoleInputHandler:IRoleInputHandler
    {
        readonly IValidation validator;
        public RoleInputHandler(IValidation validator)
        {
            this.validator = validator;
        }
        public Role Add()
        {
            Role role = new Role();
            bool checkVal;

            Console.Write("Enter  Role name : ");
            do
            {
                role.Name = Console.ReadLine();
                checkVal = validator!.CheckValidation(role.Name!, "name");
                if (!checkVal)
                    Console.WriteLine("Invalid input. Please enter the role name again: ");
            } while (!checkVal);


            Console.Write("Enter the Location : ");
            do
            {
                role.Location = Console.ReadLine();
                checkVal = validator.CheckValidation(role.Location!, "Location");
                if (!checkVal)
                    Console.WriteLine("Invalid input. Please enter the location  again: ");
            } while (!checkVal);

            Console.Write("Enter the Department : ");
            do
            {
                role.Department = Console.ReadLine();
                checkVal = validator.CheckValidation(role.Department!, "department");
                if (!checkVal)
                    Console.WriteLine("Invalid input. Please enter the department  again: ");
            } while (!checkVal);
            Console.WriteLine("Role Added Successfully");
            return role;
        }

    }
}
