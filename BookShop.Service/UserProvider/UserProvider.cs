using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BookShop.Service.UserProvider;

public class UserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    private HttpContext _context => _contextAccessor.HttpContext!;

    public string UserName => _context.User.FindFirstValue(ClaimTypes.Name)!;
    public Guid UserId => Guid.Parse(_context.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}