using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Bckend.Extensions;

public static class IdentityServiceExtentions
{
    public static IServiceCollection AddIdentityServiceExtentions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var token = configuration["TokenKey"] ?? throw new Exception("Token not configured");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token)),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

        return services;
    }
    
}