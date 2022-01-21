using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Designations.Queries.GetDesignationsById
{
    public class GetDesignationsByIdQuery : IRequest<Designation>
    {
        public int Id { get; set; }
    }

    public class GetDesignationsByIdQueryHandler : IRequestHandler<GetDesignationsByIdQuery, Designation>
    {
        private readonly IAppDbContext _context;

        public GetDesignationsByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        async Task<Designation> IRequestHandler<GetDesignationsByIdQuery, Designation>.Handle(GetDesignationsByIdQuery request, CancellationToken cancellationToken)
        {
            Designation res = await _context.Designations.Where(co => co.Id == request.Id)
                                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return res;
        }
    }
}
