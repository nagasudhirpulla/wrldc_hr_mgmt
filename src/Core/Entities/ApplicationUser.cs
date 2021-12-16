﻿using Core.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser, IHasDomainEvent
    {
        public string DisplayName { get; set; }
        public string OfficeId { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsActive { get; set; } = true;
        public string FatherName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime DateofJoining { get; set; }
        public string Gender { get; set; }
        public string EthnicOrigin { get; set; }
        public string DomicileState { get; set; }
        public string Religion { get; set; }
        public string PH_SpeciallyAbled { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string EmailId { get; set; }
        public string UAN { get; set; }
        public string PRAN { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
