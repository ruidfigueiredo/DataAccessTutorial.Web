using DataAccessTutorial.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace DataAccessTutorial.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();             
            services.AddDbContext<ProductsDbContext>(options => 
                options.UseMySQL("server=localhost;userid=root;pwd=thePassword;port=3306;database=ProductsDb;sslmode=none"));
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ProductsDbContext productsDbContext)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
                productsDbContext.Database.EnsureCreated();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
