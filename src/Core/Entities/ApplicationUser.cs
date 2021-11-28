using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string OfficeId { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
