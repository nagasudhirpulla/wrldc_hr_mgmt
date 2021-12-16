using MediatR;
using System.Collections.Generic;

namespace Application.Users.Commands.UpdateUserLatestDept
{
    public class UpdateUserLatestDeptCommand : IRequest<List<string>>
    {
        public string ApplicationUserId { get; set; }
    }
}
