using Models;
using Repository.IRepository;
using Services.Interfaces;


namespace Services
{
    public class RoleServices : IRoleServices
    {
        readonly IRepository<Role>? roleData;
        readonly IEmployeeServices employeeServices;
        public RoleServices(IEmployeeServices employeeServices, IRepository<Role> roledata)
        {
            this.employeeServices = employeeServices;
            this.roleData = roledata;
        }
        public string GenerateRoleId()
        {
            List<Role> roles = Get();
            return  $"R00{roles.Count+1}";
        }
        public void Add(Role role, List<string> employeesToAssign)
        {
            role.Id = GenerateRoleId();
            roleData!.Insert(role);
            List<Employee> employeesList = employeeServices.Get();
            foreach (Employee employee in employeesList)
            {
                if (employeesToAssign.Contains(employee.Id!))
                {
                    employee.RoleId = role.Id;
                    employeeServices.Update(employee);
                }
            }
        }

        public List<Role> Get()
        {
            List<Role> RoleList = roleData!.Get();
            return RoleList;
        }
        
        public Role Get(string id)
        {
            return roleData!.Get(id);
        }

        public Dictionary<string, string> GetRole()
        {
            List<Role> roleList = Get();
            Dictionary<string, string> roles = roleList.ToDictionary(r => r.Name!, r => r.Id!);
            return roles!;
        }

        public List<string> GetDepartment()
        {
            List<Role> roleList = roleData!.Get();
            List<string> dept =roleList.Select(r => r.Department!).ToList();
            List<string> distinctDept = dept.Distinct().ToList();
            return distinctDept;
        }

        public Dictionary<string, List<KeyValuePair<string, string>>> GetDepartmentRoles()
        {
            List<Role> roleList = roleData!.Get();

            var departmentGroups = roleList.GroupBy(r => r.Department);

            // Create a dictionary to store department to role-roleId mappings
            Dictionary<string, List<KeyValuePair<string, string>>> departmentRoles = new ();

            // Populate the dictionary
            foreach (var group in departmentGroups)
            {
                // Create a list to store role-roleId pairs for the department
                List<KeyValuePair<string, string>> rolesInDepartment = new();

                // Add role-roleId pairs to the list
                foreach (var role in group)
                {
                    rolesInDepartment.Add(new KeyValuePair<string, string>(role.Name!, role.Id!));
                }

                // Add the department and its associated roles to the dictionary
                departmentRoles.Add(group.Key!, rolesInDepartment);
            }
            return departmentRoles;
        }


    }
}
