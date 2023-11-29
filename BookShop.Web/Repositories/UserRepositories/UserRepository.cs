using BookShop.Web.DbContext;
using BookShop.Web.Entities;
using BookShop.Web.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appdbContext;

    public UserRepository( AppDbContext appdbContext)
    {
        this._appdbContext = appdbContext; }

    public async Task AddUser(User user)
    {
        await _appdbContext.Users.AddAsync(user);
        await _appdbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByUserName(string username)
    {
        var user = await _appdbContext.Users.FirstOrDefaultAsync(i => i.Username == username);
        if (user == null)
        {
            throw new UserNotFoundException(username);
        }
        return user;
    }

    public async Task<User> GetUserById(Guid userId)
    {
        var user = await _appdbContext.Users.FirstOrDefaultAsync(i => i.UserId == userId);
        if (user == null)
        {
            throw new UserNotFoundException(userId.ToString());
        }

        return user;
    }
    public async Task<bool> IsUserNameExist(string userName)
    {
        var isExists = await _appdbContext.Users.
            Where(i => i.Username == userName).AnyAsync();
        return isExists;
    }
}