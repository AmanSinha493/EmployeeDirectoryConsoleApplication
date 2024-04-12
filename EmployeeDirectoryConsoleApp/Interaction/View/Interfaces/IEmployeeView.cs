using Models;

namespace Employee_Directory_Console_App.Interaction.View.Interfaces

{
    internal interface IEmployeeView
    {
        //public void GetDetails(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
        //public Employee Add(Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
        public void DisplayEmployee(Employee employee, Role role);
        public void DisplayList(List<Employee> employeeList);
        public void DisplayById(Employee employee);
        //public Employee Edit(Employee employee, Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles);
    }
}
