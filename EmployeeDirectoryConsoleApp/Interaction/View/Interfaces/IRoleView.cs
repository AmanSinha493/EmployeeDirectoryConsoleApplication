using Models;
namespace Employee_Directory_Console_App.Interaction.View.Interfaces
{
    internal interface IRoleView
    {
        //public Role Add();
        public void DisplayList(List<Role> roleList);
        public void DisplayRole(Role role);
        public List<string> AssignEmployees();
    }
}
