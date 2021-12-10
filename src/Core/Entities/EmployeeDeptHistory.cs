using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmployeeDeptHistory : AuditableEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int OfficeId { get; set; }
        public int DepartmentId { get; set; }
        // Only DepartmentId is stored in employee table
        public Department Department { get; set; }
        [Required]
        public string DeptName { get; set; }
        public DateTime FromDate { get; set; }
    }
}
