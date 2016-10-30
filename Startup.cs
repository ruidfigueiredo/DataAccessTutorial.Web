using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessTutorial.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccessTutorial.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ProductsDbContext>(options => 
                options.UseSqlite("Data Source=productsDb.sqlite"));             
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

            //  app.Run(async (context) =>
            //  {
            //      await context.Response.WriteAsync("Hello World!");
            //  });
        }
    }
}
