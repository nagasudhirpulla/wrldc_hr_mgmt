using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Designation> Designations { get; set; }
        DbSet<EmployeeDeptHistory> EmployeeDeptHistorys { get; set; }
        DbSet<EmployeeDesignationHistory> EmployeeDesignationHistorys { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        EntityEntry Attach([NotNullAttribute] object entity);
        EntityEntry Update([NotNullAttribute] object entity);
    }
}
