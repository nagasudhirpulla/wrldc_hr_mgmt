using Application.Common.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Grades.Commands.EditGrade
{
    public class EditGradeCommandHandler : IRequestHandler<EditGradeCommand, List<string>>
    {
        private readonly ILogger<EditGradeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public EditGradeCommandHandler(ILogger<EditGradeCommandHandler> logger, IMapper mapper, IAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<string>> Handle(EditGradeCommand request, CancellationToken cancellationToken)
        {
            Grade grade = _mapper.Map<Grade>(request);
            try
            {
                _context.Update(grade);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                bool gradeExists = _context.Grades.Any(e => e.Id == grade.Id);
                if (!gradeExists)
                {
                    _logger.LogInformation($"Grade with id {grade.Id} not found while perform updates");
                    return new List<string>() { "Grade not found" };
                }
                else
                {
                    throw;
                }
            }
            return new List<string>();
        }
    }
}
