using AutoMapper;
using TestWebApp.Request.Auth;

namespace TestWebApp.AutoMapper.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, Entity.User>().ForMember(des => des.UserName, conf => conf.MapFrom(source => source.UserName))
                .ForMember(des => des.Password, conf => conf.MapFrom(source => source.Password));
        }
    }
}
