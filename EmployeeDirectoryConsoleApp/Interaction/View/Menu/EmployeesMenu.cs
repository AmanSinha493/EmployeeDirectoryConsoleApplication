using Employee_Directory_Console_App.Interaction.View.Interfaces;
using System;

namespace Employee_Directory_Console_App.Interaction.View.Menu
{
    internal class EmployeesMenu : IMenu
    {

        public void DisplayMenu()
        {
            // Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Employee Handling ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1.  Add Employee");
            Console.WriteLine("2.  Displaying Employees List");
            Console.WriteLine("3.  Displaying Particular Employee");
            Console.WriteLine("4.  Edit Employee ");
            Console.WriteLine("5.  Delete Employee");
            Console.WriteLine("6.  Return to main menu ");
        }
    }
}
