using Models;
using Newtonsoft.Json;
using Repository.IRepository;
using System;

namespace Repository
{
    public class RoleRepository : IRepository<Role>
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Role> Get()
        {
            try
            {
                using StreamReader reader = new("../../../../EmployeeDirectory.Repository/database/RolesDetail.json");
                var json = reader.ReadToEnd();
                List<Role>? Roles = JsonConvert.DeserializeObject<List<Role>>(json);
                return Roles!;
            }
            catch (Exception e)
            {  
                throw new Exception(e.Message);
            }
        }

        public Role Get(string id)
        {
            List<Role>? roleList = Get();
            Role? role = roleList.FirstOrDefault(e => e.Id == id);
            return role;
        }

        public void Insert(Role data)
        {
            List<Role>? roleList = Get();
            roleList.Add(data);
            Update(roleList);
        }

        public void Update(List<Role> List)
        {
            try
            {
                string json = JsonConvert.SerializeObject(List);
                File.WriteAllText(@"../../../../EmployeeDirectory.Repository/database/RolesDetail.json", json);
            }
            catch (Exception e) { 
                throw new Exception(e.Message);
            }
        }
        public void Update(Role data)
        {
            throw new NotImplementedException();
        }
    }
}
