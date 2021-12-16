using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeDeptHistorys.Commands.CreateDeptHistory
{
   public  class CreateDeptHistoryCommand :IRequest<List<string>>, IMapFrom<EmployeeDeptHistory>
    {
        public string ApplicationUserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime FromDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeDeptHistory, CreateDeptHistoryCommand>()
                .ReverseMap();
        }
    }
}
