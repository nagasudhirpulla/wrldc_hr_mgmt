using AutoMapper;
using Core.Entities;
using Core.ValueObjects;
using MediatR;
using System.Collections.Generic;
using static Application.Common.Mappings.MappingProfile;

namespace Application.Grades.Commands.CreateGrade
{
    public class CreateGradeCommand : IRequest<List<string>>, IMapFrom<Grade>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int PayScaleLow { get; set; }
        public int PayScaleHigh { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Grade, CreateGradeCommand>()
                .ForMember(s => s.PayScaleLow, opt => opt.MapFrom(src => src.PayScale.LowVal))
                .ForMember(s => s.PayScaleHigh, opt => opt.MapFrom(src => src.PayScale.HighVal))
                .ReverseMap()
                .ForMember(s => s.PayScale, opt => opt.MapFrom(src => new PayScale(src.PayScaleLow, src.PayScaleLow)));
        }
    }
}
