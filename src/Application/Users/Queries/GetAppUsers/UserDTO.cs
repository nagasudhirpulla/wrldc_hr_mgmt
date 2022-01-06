using AutoMapper;
using System;
using System.Text;
using Core.Entities;
using static Application.Common.Mappings.MappingProfile;
using Core.Enums;

namespace Application.Users.Queries.GetAppUsers
{
    public class UserDTO : IMapFrom<ApplicationUser>
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string OfficeId { get; set; }
        public string Designation { get; set; }
        public string Grade { get; set; }
        public DateTime? Dob { get; set; }
        public bool IsActive { get; set; } = true;
        public string PhoneNumber { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string FatherName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateofJoining { get; set; }
        public EthnicOriginEnum EthnicOrigin { get; set; }
        public string DomicileState { get; set; }
        public string Religion { get; set; }
        public SpeciallyAbledEnum SpeciallyAbled { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string UAN { get; set; }
        public string PRAN { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UserDTO>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department.Name))
                .ForMember(d => d.Designation, opt => opt.MapFrom(s => s.Designation.Name))
                .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade.Name));
        }
    }
}
