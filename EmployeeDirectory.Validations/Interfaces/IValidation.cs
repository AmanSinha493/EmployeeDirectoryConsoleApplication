using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations.Interfaces
{
    public interface IValidation
    {
        public bool CheckValidation(string text, string parameter);
    }
}
