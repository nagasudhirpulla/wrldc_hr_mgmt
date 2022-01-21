using MediatR;
using System.Collections.Generic;

namespace Application.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
