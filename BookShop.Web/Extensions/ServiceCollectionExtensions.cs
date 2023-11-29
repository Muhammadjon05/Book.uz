
using BookShop.Web.DbContext;
using BookShop.Web.Manager;
using BookShop.Web.Manager.UserManager;
using BookShop.Web.Option;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.Web.Extension;

public static  class ServiceCollectionExtensions
{
    private static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(JwtOption));
        services.Configure<JwtOption>(section);
        JwtOption jwtOptions = section.Get<JwtOption>()!;
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = System.Text.Encoding.UTF32.GetBytes(jwtOptions.SigningKey);
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtOptions.ValidIssuer,
                    ValidAudience = jwtOptions.ValidAudience,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }

    public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwt(configuration);
        services.AddScoped<JwtOption>();
        services.AddScoped<JwtTokenManager>();
        services.AddScoped<UserManager>();
        services.AddHttpContextAccessor();
        services.AddScoped<UserProvider.UserProvider>();
    }
    
}