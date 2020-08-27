using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Google.Protobuf.WellKnownTypes;

namespace CasinoBE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddControllers();
            services.AddDbContext<DBAccess>();
            services.AddMvc();
            services.AddCors(options => {
                options.AddPolicy("Allow CORS for Facebook & DevEnv", 
                    builder => builder.WithOrigins("localhost", "www.facebook.com", "localhost:8029")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCors("Allow CORS for Facebook & DevEnv");

            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("https://www.facebook.com");
            //    builder.WithOrigins("https://localhost:8029");
            //    builder.WithOrigins("http://www.facebook.com");
            //    builder.WithOrigins("http://localhost:8029");
            //    builder.AllowAnyHeader();
            //    builder.AllowAnyMethod();
            //});

            app.UseHttpsRedirection();
        }
    }
}
