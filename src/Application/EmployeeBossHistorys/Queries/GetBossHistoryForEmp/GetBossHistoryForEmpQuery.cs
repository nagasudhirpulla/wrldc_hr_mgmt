using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Queries.GetBossHistoryForEmp
{
    public class GetBossHistoryForEmpQuery : IRequest<List<EmployeeBossHistory>>
    {
        public string ApplicationUserId { get; set; }
        public class GetBossHistoryForEmpQueryHandler : IRequestHandler<GetBossHistoryForEmpQuery, List<EmployeeBossHistory>>
        {
            private readonly IAppDbContext _context;

            public GetBossHistoryForEmpQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeBossHistory>> Handle(GetBossHistoryForEmpQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeBossHistory> res = await _context.EmployeeBossHistorys
                                                    .Where(e => e.ApplicationUserId == request.ApplicationUserId)
                                                    .Include(e => e.ApplicationUser)
                                                    .Include(e => e.BossUser)
                                                    .ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
