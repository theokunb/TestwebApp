using AutoMapper;
using TestWebApp.Request;

namespace TestWebApp.AutoMapper.Task
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTask, Entity.MyTask>().ForMember(des => des.Header, conf => conf.MapFrom(source => source.Header))
                .ForMember(des => des.Description, conf => conf.MapFrom(source => source.Description));
        }
    }
}
