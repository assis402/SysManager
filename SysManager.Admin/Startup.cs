using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SysManager.Application.Data.MySql;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.Admin
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
        }

        public void BeforeConfigureServices(IServiceCollection services)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            BeforeConfigureServices(services);
            services.AddApiVersioning();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddScoped<UserService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ProductTypeService>();
            services.AddScoped<UnityService>();

            services.AddScoped<UserRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductTypeRepository>();
            services.AddScoped<UnityRepository>();

            services.AddScoped<MySqlContext>();
            services.Configure<AppConnectionSettings>(option => Configuration.GetSection("ConnectionStrings").Bind(option));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();
        }
    }
}