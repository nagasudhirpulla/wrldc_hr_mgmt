using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using static Application.Common.Mappings.MappingProfile;
using System;
using Core.Enums;

namespace Application.Users.Commands.EditUser
{
    public class EditUserCommand : IRequest<List<string>>, IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserRole { get; set; }
        public string OfficeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public string FatherName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime DateofJoining { get; set; }
        public int Gender { get; set; }
        public int EthnicOrigin { get; set; }
        public string DomicileState { get; set; }
        public string Religion { get; set; }
        public int SpeciallyAbled { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string UAN { get; set; }
        public string PRAN { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, EditUserCommand>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.IsTwoFactorEnabled, opt => opt.MapFrom(s => s.TwoFactorEnabled))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender.Value))
                .ForMember(d => d.EthnicOrigin, opt => opt.MapFrom(s => s.EthnicOrigin.Value))
                .ForMember(d => d.SpeciallyAbled, opt => opt.MapFrom(s => s.SpeciallyAbled.Value));
        }
    }
}
