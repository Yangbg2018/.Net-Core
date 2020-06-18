using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using firstApp.Services;
using firstApp.Model;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace firstApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IWelcomeService, WelcomeService>();
            services.AddSingleton<IRespository<Student>,Respository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IWelcomeService welcomeService, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            
            //app.UseMvc(builder =>
            //{
            //    builder.MapRoute("hello", "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvcWithDefaultRoute();


            //defaultfilesoptions options = new defaultfilesoptions();
            //options.defaultfilenames.clear();
            //options.defaultfilenames.add("zidingyi.html");
            //app.usedefaultfiles();
            //app.usestaticfiles();
            //app.UseFileServer();
            app.Use(next =>
            {
                logger.LogInformation("Use....");
                return async HttpContext =>
              {
                  if (HttpContext.Request.Path.StartsWithSegments("/first"))
                  {
                      logger.LogInformation("first....");
                      await HttpContext.Response.WriteAsync("first!!!!!");
                  }
                  else
                  {
                      logger.LogInformation("HttpContext....");
                      await next(HttpContext);
                  }
              };
            });
            app.Run(async (context) =>
            {
                //var welcome = configuration["Welcome"];IConfiguration configuration,
                string welcome = welcomeService.GetMessage();
                logger.LogInformation("HttpContext....");
                await context.Response.WriteAsync(welcome);
            });
        }
    }
}
