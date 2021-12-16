using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeDeptHistorys.Commands.EditDeptHistory
{
    public class EditDeptHistoryCommand : IRequest<List<string>>, IMapFrom<EmployeeDeptHistory>
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public int DepartmentId { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeDeptHistory, EditDeptHistoryCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
