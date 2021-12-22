using AutoMapper;
using Book_API.Dtos.Book;
using Book_API.Models;

namespace Book_API
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<AddBookDto, Book>();
        }
    }
}
