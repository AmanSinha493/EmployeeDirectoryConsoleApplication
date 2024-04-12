using System;

using System.Text.RegularExpressions;
using Validations.Interfaces;
using Services.Interfaces;

namespace Validations
{
    public class Validation : IValidation
    {
        readonly IEmployeeServices services;
        public Validation(IEmployeeServices obj)
        {
            services = obj;
        }
        public bool CheckValidation(string text, string parameter)
        {

            if (String.IsNullOrEmpty(text))
            {
                return false;
            }
            bool flag = true;
            switch (parameter)
            {
                case "id":
                    List<string> employees = services!.GetEmployeeIds();
                    string pattern = @"^TZ+\d{4}$";
                    Regex rg = new(pattern);
                    flag = rg.IsMatch(text!) && !employees.Any(e => e == text);
                    break;
                case "name":
                    pattern = @"^[A-Za-z]+$";
                    rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
                case "email":
                    pattern = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.]+\.[a-zA-Z]{2,}$";
                    rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
                case "mobile":
                    pattern = @"^[1-9][0-9]{9}$";
                    rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
                case "date":
                    flag = DateTime.TryParse(text, out DateTime parsedDate);
                    break;
            }
            return flag;
        }
    }
}
