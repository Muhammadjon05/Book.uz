using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Models;
using Book.uz.Repositories.UserRepositories;


namespace Book.uz.Manager;
 
public class AuthorManager 
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AuthorModel> AddAuthor(AuthorDto dto)
    {
        
        var author = new Author()
        {
            AuthorEmail = dto.AuthorEmail,
            AuthorName = dto.AuthorName,
            AuthorLastName = dto.AuthorLastName
        };
        await _authorRepository.AddAuthor(author);
        return ToAuthorModel(author);
    }

    private AuthorModel ToAuthorModel(Author author)
    {
        var model = new AuthorModel();//author.Adapt<AuthorModel>();
        return model;
    }
}