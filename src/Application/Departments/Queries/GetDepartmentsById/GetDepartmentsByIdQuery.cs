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

namespace Application.Departments.Queries.GetDepartmentsById
{
    public class GetDepartmentsByIdQuery : IRequest<Department>
    {
        public int Id { get; set; }
    }

    public class GetNotesheetByIdQueryHandler : IRequestHandler<GetDepartmentsByIdQuery, Department>
    {
        private readonly IAppDbContext _context;

        public GetNotesheetByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        async Task<Department> IRequestHandler<GetDepartmentsByIdQuery, Department>.Handle(GetDepartmentsByIdQuery request, CancellationToken cancellationToken)
        {
            Department res = await _context.Departments.Where(co => co.Id == request.Id)
                                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return res;
        }
    }
}
