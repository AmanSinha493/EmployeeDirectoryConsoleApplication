using Employee_Directory_Console_App.Interaction.View.Interfaces;
using System;

namespace Employee_Directory_Console_App.Interaction.View.Menu
{
    internal class RolesMenu : IMenu
    {
        public void DisplayMenu()
        {
            // Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Role Handling ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Displaying Role List");
            Console.WriteLine("3. Return to main menu ");
        }
    }
}
