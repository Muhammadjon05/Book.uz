﻿using BookShop.Web.Entities;
using BookShop.Web.Enums;

namespace BookShop.Web.DtoModels;

public class BookDto
{
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<AuthorDto> AuthoInfo { get; set; }
}