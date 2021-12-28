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

namespace Application.EmployeeDeptHistorys.Queries.GetDeptHistoryForEmp
{
    public class GetDeptHistoryForEmpQuery : IRequest<List<EmployeeDeptHistory>>
    {
        public string ApplicationUserId { get; set; }
        public class GetDeptHistoryForEmpQueryHandler : IRequestHandler<GetDeptHistoryForEmpQuery, List<EmployeeDeptHistory>>
        {
            private readonly IAppDbContext _context;

            public GetDeptHistoryForEmpQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeDeptHistory>> Handle(GetDeptHistoryForEmpQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeDeptHistory> res = await _context.EmployeeDeptHistorys
                                                    .Where(e => e.ApplicationUserId == request.ApplicationUserId)
                                                    .Include(e => e.Department)
                                                    .Include(e => e.ApplicationUser)
                                                    .ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
