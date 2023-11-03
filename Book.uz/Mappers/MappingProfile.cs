using AutoMapper;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Models;

namespace Book.uz.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDto,Entities.Book>();
        CreateMap<Entities.Book,BookModel>();
        CreateMap<Author, AuthorModel>();
        CreateMap<AuthorDto, Author>();
        CreateMap<Review, ReviewModel>();
        CreateMap<ReviewDto, Review>();
        CreateMap<CategoryDto, Category>();
        CreateMap<Category, CategoryModel>();
        CreateMap<Order, OrderModel>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
    }
}