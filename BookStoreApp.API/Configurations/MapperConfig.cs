namespace BookStoreApp.API.Configurations;

using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<AuthorCreateDto, Author>().ReverseMap();
        CreateMap<AuthorUpdateDto, Author>().ReverseMap();
        CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
    }
}
