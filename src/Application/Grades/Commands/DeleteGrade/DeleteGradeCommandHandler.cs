using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, List<string>>
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<DeleteGradeCommandHandler> _logger;

        public DeleteGradeCommandHandler(IAppDbContext context, ILogger<DeleteGradeCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<string>> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            List<string> errors = new();
            Grade grd = await _context.Grades
                        .Where(g => g.Id == request.Id)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (grd == null)
            {
                errors.Add($"Grade not found with id {request.Id}");
            }
            else
            {
                _context.Grades.Remove(grd);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return errors;
        }
    }
}
