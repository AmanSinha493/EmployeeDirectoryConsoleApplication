using CommandLine;
using System;


namespace EmployeeDirectory.Models
{
    public class Commands
    {
        //[Option("employee", HelpText = "Go to employee menu")]
        //public bool Employee { get; set; }

        //[Option("role", HelpText = "Go to role menu")]
        //public bool Role { get; set; }

        //[Option("exit", HelpText = "Exit Program")]
        //public bool Exit { get; set; }

        [Option("command", Default = 0, HelpText = "Enter command (1 for employee, 2 for role, 3 to exit)")]
        public int Command { get; set; }

    }
}
