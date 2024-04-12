using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Directory_Console_App.ServiceHandler.Interfaces
{
    public interface IServiceHandler<T>
    {
        public void HandleServices();
    }
}
