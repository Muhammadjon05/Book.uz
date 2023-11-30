namespace BookShop.Domain.DtoModels;

public class AuthorDto
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}