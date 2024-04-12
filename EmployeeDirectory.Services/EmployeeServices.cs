using Models;
using Repository.IRepository;
using Services.Interfaces;

namespace Services
{
    public class EmployeeServices : IEmployeeServices
    {
        IRepository<Employee>? employeeData;
        public EmployeeServices(IRepository<Employee> employeeData)
        {
            this.employeeData = employeeData;
        }
        public void Add(Employee employee)
        {
            employeeData.Insert(employee);
        }

        public void Delete(string id)
        {
            employeeData.Delete(id);
        }

        public Employee Get(string id)
        {
            return employeeData.Get(id);
        }

        public List<Employee> Get()
        {
            List<Employee> employeelist = employeeData.Get();
            return employeelist;
        }
        public bool CheckEmployee(string id)
        {
            List<string> employeeIds = GetEmployeeIds();
            return employeeIds.Contains(id);
        }
        public List<string> GetEmployeeIds()
        {
            List<Employee> employeesList = Get();
            return employeesList.Select(e => e.Id).ToList();
        }
        public void Edit(Employee employee)
        {
            employeeData.Update(employee);
        }

        public void Update(List<Employee> employeeList)
        {
            employeeData.Update(employeeList);
        }
        public void Update(Employee employee)
        {
            employeeData.Update(employee);
        }
    }
}
