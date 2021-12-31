using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
