using BookShop.Domain.Enums;

namespace BookShop.Domain.DtoModels;

public class BookDto
{
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<AuthorDto> AuthoInfo { get; set; }
}