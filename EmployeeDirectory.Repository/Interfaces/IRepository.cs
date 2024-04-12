using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRepository<T>
    {
        public void Update(List<T> List);
        public List<T> Get();
        public T Get(string id);
        public void Update(T data);
        public void Insert(T data);
        public bool Delete(string id);
    }
}
