using Application.Common.Interfaces;
using Core.Entities;
using Core.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Grades.Commands.SeedGrades
{
    public class SeedGradesCommand : IRequest<bool>
    {
        public List<string> SeedGrades { get; set; } = new() { "NA" };
        public class SeedGradesCommandHandler : IRequestHandler<SeedGradesCommand, bool>
        {
            private readonly IAppDbContext _context;

            public SeedGradesCommandHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(SeedGradesCommand request, CancellationToken cancellationToken)
            {
                foreach (var grd in request.SeedGrades)
                {
                    bool isGradePres = await _context.Grades.AnyAsync(d => d.Name.ToLower().Equals(grd.ToLower()), cancellationToken: cancellationToken);
                    if (!isGradePres)
                    {
                        _context.Grades.Add(new Grade() { Name = grd, PayScale = new(0, 0) });
                        _ = await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                return true;
            }
        }
    }
}
