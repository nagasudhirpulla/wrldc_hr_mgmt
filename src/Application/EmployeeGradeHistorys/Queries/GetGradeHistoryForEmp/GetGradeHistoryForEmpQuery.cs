using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.Queries.GetGradeHistoryForEmp
{
    public class GetGradeHistoryForEmpQuery : IRequest<List<EmployeeGradeHistory>>
    {
        public string ApplicationUserId { get; set; }
        public class GetGradeHistoryForEmpQueryHandler : IRequestHandler<GetGradeHistoryForEmpQuery, List<EmployeeGradeHistory>>
        {
            private readonly IAppDbContext _context;

            public GetGradeHistoryForEmpQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeGradeHistory>> Handle(GetGradeHistoryForEmpQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeGradeHistory> res = await _context.EmployeeGradeHistorys
                                                    .Where(e => e.ApplicationUserId == request.ApplicationUserId)
                                                    .Include(e => e.Grade)
                                                    .Include(e => e.ApplicationUser)
                                                    .ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
