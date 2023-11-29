using BookShop.Web.Entities;

namespace BookShop.Web.Repositories.UserRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User> GetUserByUserName(string username);
    Task<User> GetUserById(Guid userId);
    Task<bool> IsUserNameExist(string userName);

}