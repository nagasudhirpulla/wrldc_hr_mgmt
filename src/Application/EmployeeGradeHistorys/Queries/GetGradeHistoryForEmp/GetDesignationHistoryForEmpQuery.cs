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

namespace Application.EmployeeDesignationHistorys.Queries.GetDesignationHistoryForEmp
{
    public class GetDesignationHistoryForEmpQuery : IRequest<List<EmployeeDesignationHistory>>
    {
        public string ApplicationUserId { get; set; }
        public class GetDesignationHistoryForEmpQueryHandler : IRequestHandler<GetDesignationHistoryForEmpQuery, List<EmployeeDesignationHistory>>
        {
            private readonly IAppDbContext _context;

            public GetDesignationHistoryForEmpQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeDesignationHistory>> Handle(GetDesignationHistoryForEmpQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeDesignationHistory> res = await _context.EmployeeDesignationHistorys
                                                    .Where(e => e.ApplicationUserId == request.ApplicationUserId)
                                                    .Include(e => e.Designation)
                                                    .Include(e => e.ApplicationUser)
                                                    .ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
