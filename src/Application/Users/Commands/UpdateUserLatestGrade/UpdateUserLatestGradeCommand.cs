using MediatR;
using System.Collections.Generic;

namespace Application.Users.Commands.UpdateUserLatestGrade
{
    public class UpdateUserLatestGradeCommand : IRequest<List<string>>
    {
        public string ApplicationUserId { get; set; }
    }
}
