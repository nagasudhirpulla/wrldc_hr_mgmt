using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeGradeHistorys.Commands.EditGradeHistory
{
    public class EditGradeHistoryCommand : IRequest<List<string>>, IMapFrom<EmployeeGradeHistory>
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime FromDate { get; set; }
        public int GradeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeGradeHistory, EditGradeHistoryCommand>();
        }
    }
}
