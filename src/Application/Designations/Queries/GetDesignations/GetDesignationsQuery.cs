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

namespace Application.Designations.Queries.GetDesignations
{
    public class GetDesignationsQuery : IRequest<List<Designation>>
    {
        public class GetDesignationsQueryHandler : IRequestHandler<GetDesignationsQuery, List<Designation>>
        {
            private readonly IAppDbContext _context;

            public GetDesignationsQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Designation>> Handle(GetDesignationsQuery request, CancellationToken cancellationToken)
            {
                List<Designation> res = await _context.Designations.ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}
