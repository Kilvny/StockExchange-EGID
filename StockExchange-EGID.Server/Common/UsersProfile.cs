using AutoMapper;
using StockExchange_EGID.Server.Domain.Entities;
using StockExchange_EGID.Server.Models;

namespace StockExchange_EGID.Server.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateUserDto, User>()
                .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));

        }
    }
}
