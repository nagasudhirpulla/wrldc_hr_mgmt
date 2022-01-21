using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDesignationHistorys.Queries.GetEmpDesignationHistById
{
    public class GetEmpDesignationHistByIdQuery : IRequest<EmployeeDesignationHistory>
    {
        public int Id { get; set; }
        public class GetEmpDesignationHistByIdQueryHandler : IRequestHandler<GetEmpDesignationHistByIdQuery, EmployeeDesignationHistory>
        {
            private readonly IAppDbContext _context;

            public GetEmpDesignationHistByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<EmployeeDesignationHistory> Handle(GetEmpDesignationHistByIdQuery request, CancellationToken cancellationToken)
            {
                EmployeeDesignationHistory res = await _context.EmployeeDesignationHistorys
                                            .Include(e => e.Designation).Include(e => e.ApplicationUser)
                                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
