using Microsoft.Build.Framework;

namespace Book.uz.DtoModels;

public class AuthorDto
{
    [Required]
    public string AuthorName { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorEmail { get; set; }
}