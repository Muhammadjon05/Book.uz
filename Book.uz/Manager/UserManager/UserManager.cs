using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Book.uz.Manager;

public class UserManager
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenManager _jwtTokenManager;

    public UserManager(IUserRepository userRepository, JwtTokenManager jwtTokenManager)
    {
        _userRepository = userRepository;
        _jwtTokenManager = jwtTokenManager;
    }

    public async Task<UserModel> Register(UserDto dto)
    {
        if (await _userRepository.IsUserNameExist(dto.Username))
        {
            throw new UsernameExistException(dto.Username);
        }

        var user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password
        };
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user,dto.Password);
        await _userRepository.AddUser(user);
        return ParseToUserModel(user);
    }
    public async Task<string> Login(LoginDto model)
    {
        var userName = await _userRepository.GetUserByUserName(model.UserName);
        var result = new PasswordHasher<User>().
            VerifyHashedPassword(userName, userName.PasswordHash, model.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new InCorrectPassword(model.Password);
        }
        var token = _jwtTokenManager.GenerateToken(userName);
        return token;
    }
    public async Task<UserModel> GetUser(string username)
    {
        var user= await _userRepository.GetUserByUserName(username);
        return ParseToUserModel(user);
    }
    public async Task<UserModel?> GetUser(Guid id)
    {
        var user= await _userRepository.GetUserById(id);
        return ParseToUserModel(user);
    }
    private UserModel ParseToUserModel(User user)
    {
        var model = new UserModel()
        {
            UserId = user.UserId,
            Firstname = user.FirstName,
            Lastname = user.LastName,
            Username = user.Username,
        };
        return model;
    }

}