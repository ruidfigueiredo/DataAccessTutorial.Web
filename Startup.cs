using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DataAccessTutorial.Web.Models;

namespace DataAccessTutorial.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseNpgsql("User ID=postgres;Password=YourPassword;Host=localhost;Port=5432;Database=ProductsDb;Pooling=true;"));             
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            //  app.Run(async (context) =>
            //  {
            //      await context.Response.WriteAsync("Hello World!");
            //  });
        }
    }
}
