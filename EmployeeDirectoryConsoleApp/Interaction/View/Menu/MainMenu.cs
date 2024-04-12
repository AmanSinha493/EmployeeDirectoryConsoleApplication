using Employee_Directory_Console_App.Interaction.View.Interfaces;
using System;


namespace Employee_Directory_Console_App.Interaction.View.Menu
{
    internal class MainMenu : IMenu
    {

        public void DisplayMenu()
        {
            // Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Main Menu ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1.  Employees Management");
            Console.WriteLine("2.  Role Management");
            Console.WriteLine("3.  Exit program");
        }
    }
}
