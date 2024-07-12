using AutoMapper;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class UserDTORequestMapper:Profile
    {
        public UserDTORequestMapper()
        {
            CreateMap<User, UserRequestDTO>()
                .ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                })
                .ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.LastName);
                })
                .ForMember(dest => dest.UserName, opt =>
                {
                    opt.MapFrom(src => src.UserName);
                })
                .ForMember(dest => dest.Password, opt =>
                {
                    opt.MapFrom(src => src.Password);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.Phone, opt =>
                {
                    opt.MapFrom(src => src.Phone);
                })
                .ForMember(dest => dest.Adress, opt =>
                {
                    opt.MapFrom(src => src.Adress);
                }).ReverseMap();
        }
    }
}
