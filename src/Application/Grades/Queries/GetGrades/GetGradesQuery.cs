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

namespace Application.Grades.Queries.GetGrades
{
    public class GetGradesQuery : IRequest<List<Grade>>
    {
        public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, List<Grade>>
        {
            private readonly IAppDbContext _context;

            public GetGradesQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Grade>> Handle(GetGradesQuery request, CancellationToken cancellationToken)
            {
                List<Grade> res = await _context.Grades.OrderByDescending(g => g.Level).ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
