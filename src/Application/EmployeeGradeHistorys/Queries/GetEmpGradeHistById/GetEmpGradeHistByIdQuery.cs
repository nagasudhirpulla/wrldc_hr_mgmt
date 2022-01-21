using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.Queries.GetEmpGradeHistById
{
    public class GetEmpGradeHistByIdQuery : IRequest<EmployeeGradeHistory>
    {
        public int Id { get; set; }
        public class GetEmpGradeHistByIdQueryHandler : IRequestHandler<GetEmpGradeHistByIdQuery, EmployeeGradeHistory>
        {
            private readonly IAppDbContext _context;

            public GetEmpGradeHistByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<EmployeeGradeHistory> Handle(GetEmpGradeHistByIdQuery request, CancellationToken cancellationToken)
            {
                EmployeeGradeHistory res = await _context.EmployeeGradeHistorys
                                            .Include(e => e.Grade).Include(e => e.ApplicationUser)
                                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
