using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoleServices
    {
        public void Add(Role role,List<string> employeesToAssign);
        public List<Role> Get();
        public Role Get(string id);
        public Dictionary<string, string> GetRole();
        public List<string> GetDepartment();
        public Dictionary<string, List<KeyValuePair<string, string>>> GetDepartmentRoles();
    }
}
