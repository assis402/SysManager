using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SysManager.Admin
{
    public class Startup
    {
        public void BeforeConfigureServices(IServiceCollection services)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            BeforeConfigureServices(services);
            services.AddApiVersioning();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
