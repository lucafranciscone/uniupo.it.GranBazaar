﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using GranBazar.Data;
using Microsoft.EntityFrameworkCore;
using GranBazar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GranBazar
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }//aggiunto

        public Startup(IHostingEnvironment env)//aggiunto
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }





        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BazarContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly("GranBazar")
                )
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

           
            //handler globale
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
                
            });



     

        }
    }
}
