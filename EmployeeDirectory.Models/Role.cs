using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role
    {
        [Key]
        public string ?Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public string? Description { get; set; }
    }
}
