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

namespace Application.Grades.Queries.GetGradeById
{
    public class GetGradeByIdQuery : IRequest<Grade>
    {
        public int Id { get; set; }
    }

    public class GetNotesheetByIdQueryHandler : IRequestHandler<GetGradeByIdQuery, Grade>
    {
        private readonly IAppDbContext _context;

        public GetNotesheetByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        async Task<Grade> IRequestHandler<GetGradeByIdQuery, Grade>.Handle(GetGradeByIdQuery request, CancellationToken cancellationToken)
        {
            Grade res = await _context.Grades.Where(co => co.Id == request.Id)
                                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return res;
        }
    }
}
