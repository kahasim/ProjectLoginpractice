using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice1.Models
{
    public class HospitalDepartment
    {
        
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public Employee Employee { get;set; }
 
    }
}
