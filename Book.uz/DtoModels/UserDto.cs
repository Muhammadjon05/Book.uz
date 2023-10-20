using System.ComponentModel.DataAnnotations;

namespace Book.uz.DtoModels;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}