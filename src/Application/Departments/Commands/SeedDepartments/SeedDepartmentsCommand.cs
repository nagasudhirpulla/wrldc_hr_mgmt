using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Core.Entities;

namespace Application.Departments.Commands.SeedDepartments
{
    public class SeedDepartmentsCommand : IRequest<bool>
    {
        public List<string> SeedDepts { get; set; } = new() { "NA" };
        public class SeedDepartmentsCommandHandler : IRequestHandler<SeedDepartmentsCommand, bool>
        {
            private readonly IAppDbContext _context;

            public SeedDepartmentsCommandHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(SeedDepartmentsCommand request, CancellationToken cancellationToken)
            {
                foreach (var dept in request.SeedDepts)
                {
                    bool isDeptPres = await _context.Departments.AnyAsync(d => d.Name.ToLower().Equals(dept.ToLower()), cancellationToken: cancellationToken);
                    if (!isDeptPres)
                    {
                        _context.Departments.Add(new Department() { Name = dept });
                        _ = await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                return true;
            }
        }
    }
}
