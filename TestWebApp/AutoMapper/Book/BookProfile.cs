using AutoMapper;
using TestWebApp.Request.Books;

namespace TestWebApp.AutoMapper.Book
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookRequest, Entity.Book>().ForMember(des => des.BookName, conf => conf.MapFrom(source => source.BookName))
                .ForMember(des => des.Author, conf => conf.MapFrom(source => source.Author))
                .ForMember(des => des.Price, conf => conf.MapFrom(source => source.Price))
                .ForMember(des => des.Category, conf => conf.MapFrom(source => source.Category));

            CreateMap<UpdateBookRequest, Entity.Book>().ForMember(des => des.BookName, conf => conf.MapFrom(source => source.BookName))
                .ForMember(des => des.Author, conf => conf.MapFrom(source => source.Author))
                .ForMember(des => des.Price, conf => conf.MapFrom(source => source.Price))
                .ForMember(des => des.Category, conf => conf.MapFrom(source => source.Category));
        }
    }
}
