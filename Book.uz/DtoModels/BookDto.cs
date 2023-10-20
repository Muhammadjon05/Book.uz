using Book.uz.Enums;

namespace Book.uz.DtoModels;

public class BookDto
{
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public Guid CategoryId { get; set; }
}