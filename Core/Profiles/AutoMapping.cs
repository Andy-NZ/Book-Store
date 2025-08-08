using AutoMapper;
using BookStore.Models;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        CreateMap<NewBookDto, Book>();
    }
}