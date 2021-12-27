using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Queries.GetEmpDeptHistById
{
    public class GetEmpDesignationHistByIdQuery : IRequest<EmployeeDeptHistory>
    {
        public int Id { get; set; }
        public class GetEmpDeptHistByIdQueryHandler : IRequestHandler<GetEmpDesignationHistByIdQuery, EmployeeDeptHistory>
        {
            private readonly IAppDbContext _context;

            public GetEmpDeptHistByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<EmployeeDeptHistory> Handle(GetEmpDesignationHistByIdQuery request, CancellationToken cancellationToken)
            {
                EmployeeDeptHistory res = await _context.EmployeeDeptHistorys
                                            .Include(e => e.Department).Include(e => e.ApplicationUser)
                                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
