//using DNH.Cache;
using DNHCore;
using DNHCore.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace project_api.StartUp
{
    public class AuthStartUp : IDNHStartup
    {
        public int Order => 1;

        public bool Active => true;

        public void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            if (ID4ClientConfig.setting == null)
            {
                var config = Configuration.GetSection("ID4ClientConfig");
                ID4ClientConfig authConfig = new ID4ClientConfig();
                config.Bind(authConfig);
                ID4ClientConfig.setting = authConfig;
            }
            string tenantId = "4739b193-439d-4704-ac83-2e4ad0760fb6";
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = $"https://login.microsoftonline.com/{tenantId}/v2.0"; // Thay thế {your-tenant-id} bằng ID của tenant Azure AD của bạn
                    options.Audience = "36378791-f68e-4a6a-b138-f8490823003c"; // Thay thế "scope" 

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = $"https://login.microsoftonline.com/{tenantId}/v2.0",
                        ValidAudience = ""
                    };
                });

        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseHttpsRedirection();
            application.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials

            //  application.UseCors(MainConfig.CorsPublic);
            application.UseAuthentication();
            application.UseAuthorization();
        }


    }
}
