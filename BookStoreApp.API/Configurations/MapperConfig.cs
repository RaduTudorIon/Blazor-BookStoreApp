namespace BookStoreApp.API.Configurations;

using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<AuthorCreateDto, Author>().ReverseMap();
        CreateMap<AuthorUpdateDto, Author>().ReverseMap();
        CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();

        CreateMap<Book, BookReadOnlyDto>()
            .ForMember(destinationMember: x => x.AuthorName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}")).ReverseMap();
        CreateMap<Book, BookDetailsDto>()
            .ForMember(destinationMember: x => x.AuthorName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}")).ReverseMap();
        CreateMap<BookCreateDto, Book>().ReverseMap();
        CreateMap<BookUpdateDto, Book>().ReverseMap();
    }
}
