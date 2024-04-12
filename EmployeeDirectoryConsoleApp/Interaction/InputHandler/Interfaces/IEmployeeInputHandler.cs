using Models;

namespace Employee_Directory_Console_App.Interaction.InputHandler.Interfaces
{
    public interface IEmployeeInputHandler
    {
        public void GetDetails(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
        public Employee Add(Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
        public Employee Edit(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
    }
}
