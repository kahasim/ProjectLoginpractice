using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice1.Models
{
    public class Join
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
