using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeDesignationHistorys.Commands.EditDesignationHistory
{
    public class EditDesignationHistoryCommand : IRequest<List<string>>, IMapFrom<EmployeeDesignationHistory>
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime FromDate { get; set; }
        public int DesignationId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeDesignationHistory, EditDesignationHistoryCommand>();
        }
    }
}
