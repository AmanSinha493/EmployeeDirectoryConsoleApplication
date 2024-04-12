using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Employee
    {
        [Key]
        public string? Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
        public string? MobileNo { get; set; }
        public string? JoiningDate { get; set; }
        public string? Dob { get; set; }
        public string? Manager { get; set; }
        public string? Project { get; set; }
    }
}
