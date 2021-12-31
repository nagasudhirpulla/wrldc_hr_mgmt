using Application.Grades.Commands.CreateGrade;
using AutoMapper;
using Core.Entities;
using Core.ValueObjects;
using static Application.Common.Mappings.MappingProfile;

namespace Application.Grades.Commands.EditGrade
{
    public class EditGradeCommand : CreateGradeCommand, IMapFrom<Grade>
    {
        public int Id { get; set; }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Grade, EditGradeCommand>()
                .ForMember(s => s.PayScaleLow, opt => opt.MapFrom(src => src.PayScale.LowVal))
                .ForMember(s => s.PayScaleHigh, opt => opt.MapFrom(src => src.PayScale.HighVal))
                .ReverseMap()
                .ForMember(s => s.PayScale, opt => opt.MapFrom(src => new PayScale(src.PayScaleLow, src.PayScaleLow)));
        }
    }
}
