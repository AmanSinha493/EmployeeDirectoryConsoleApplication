using System;
using Newtonsoft.Json;
using Repository.IRepository;
using Models;
using System.Collections.Generic;



namespace Repository
{
    
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Delete(string id)
        {
            List<Employee>? employeeList = Get();
            bool dltFlag = false;
            Employee? employeeToRemove = employeeList.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                employeeList.Remove(employeeToRemove);
                Update(employeeList);
                dltFlag = true;
            }
            return dltFlag;
        }
        public List<Employee> Get()
        {
            try
            {
                using StreamReader reader = new("../../../../EmployeeDirectory.Repository/database/EmployeesDetail.json");
                var json = reader.ReadToEnd();
                List<Employee>? Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                return Employees!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee Get(string id)
        {
            List<Employee>? employeeList = Get();
            Employee? employee = employeeList.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public void Insert(Employee data)
        {
            List<Employee>? employeeList = Get();
            employeeList.Add(data);
            Update(employeeList);
        }

        public void Update(Employee employee)
        {
            List<Employee> employeeList = Get();
            int index = employeeList.FindIndex(e => e.Id == employee.Id);
            employeeList[index] = employee;
            try
            {
                string json = JsonConvert.SerializeObject(employeeList);
                File.WriteAllText(@"../../../../EmployeeDirectory.Repository/database/EmployeesDetail.json", json);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(List<Employee> List)
        {
            try
            {
                string json = JsonConvert.SerializeObject(List);
                File.WriteAllText(@"../../../../EmployeeDirectory.Repository/database/EmployeesDetail.json", json);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
