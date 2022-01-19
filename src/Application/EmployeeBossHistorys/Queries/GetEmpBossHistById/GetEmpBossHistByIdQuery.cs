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

namespace Application.EmployeeBossHistorys.Queries.GetEmpBossHistById
{
    public class GetEmpBossHistByIdQuery : IRequest<EmployeeBossHistory>
    {
        public int Id { get; set; }
        public class GetEmpBossHistByIdQueryHandler : IRequestHandler<GetEmpBossHistByIdQuery, EmployeeBossHistory>
        {
            private readonly IAppDbContext _context;

            public GetEmpBossHistByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<EmployeeBossHistory> Handle(GetEmpBossHistByIdQuery request, CancellationToken cancellationToken)
            {
                EmployeeBossHistory res = await _context.EmployeeBossHistorys
                                            .Include(e => e.ApplicationUser)
                                            .Include(e => e.BossUser)
                                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
