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

namespace Application.Designations.Commands.SeedDesignations
{
    public class SeedDesignationsCommand : IRequest<bool>
    {
        public List<Tuple<string, string, int>> SeedDesigs { get; set; } = new() { new Tuple<string, string, int>("NA", "NA", 0) };
        public class SeedDesignationsCommandHandler : IRequestHandler<SeedDesignationsCommand, bool>
        {
            private readonly IAppDbContext _context;

            public SeedDesignationsCommandHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(SeedDesignationsCommand request, CancellationToken cancellationToken)
            {
                foreach (var des in request.SeedDesigs)
                {
                    bool isDesigPres = await _context.Designations.AnyAsync(d => d.Name.ToLower().Equals(des.Item1.ToLower()), cancellationToken: cancellationToken);
                    if (!isDesigPres)
                    {
                        _context.Designations.Add(new Designation() { Name = des.Item1, Grade = des.Item2, Level = des.Item3 });
                        _ = await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                return true;
            }
        }
    }
}
