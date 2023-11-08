using Book.uz.Entities;

namespace Book.uz.Repositories.UserRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User> GetUserByUserName(string username);
    Task<User> GetUserById(Guid userId);
    Task<bool> IsUserNameExist(string userName);

}