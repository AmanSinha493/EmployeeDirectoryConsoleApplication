using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeServices
    {
        public void Add(Employee employee);
        public List<Employee> Get();
        public void Delete(string id);
        public void Edit(Employee employee);
        public Employee Get(string id);

        public List<string> GetEmployeeIds();
        public bool CheckEmployee(string id);
        public void Update(Employee employee);
        public void Update(List<Employee> employeeList);
    }
}
