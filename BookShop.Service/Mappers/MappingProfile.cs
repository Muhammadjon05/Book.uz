using AutoMapper;
using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDto,Book>();
        CreateMap<Book,BookModel>();
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