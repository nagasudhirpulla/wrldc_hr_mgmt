using Application.Common.Interfaces;
using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Grades.Commands.CreateGrade
{
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, List<string>>
    {
        private readonly ILogger<CreateGradeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public CreateGradeCommandHandler(ILogger<CreateGradeCommandHandler> logger, IMapper mapper, IAppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<string>> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            Grade grade = _mapper.Map<Grade>(request);
            _context.Grades.Add(grade);
            _ = await _context.SaveChangesAsync(cancellationToken);
            return new List<string>();
        }
    }
}
