using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GranBazar.Data;
using Microsoft.EntityFrameworkCore;
using GranBazar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GranBazar
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

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

			//Serve per aggiungere HttpContextAccessor nelle Views, in questo modo evito di doverle iniettare in ogni pagina in cui mi serve lavorarci
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			
            services.AddMvc();

            //Servono per la sessione
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600);
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			
			//Session
            app.UseSession();
			
            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

			//Handler globale, se qualche pagina non esiste rimando a Not Found
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
				"<html>\n" +
                    "<head>\n<title>Pagina non trovata</title>\n" +
						"<link rel=\"stylesheet\" type=\"text/css\" href=\"./styles/StyleSheet.css\">\n" +
                    "</head>\n" + 
					"<body>\n<div class=\"error\">\n"+
								"<div class=\"error-code m-b-10 m-t-20\">404 <i class=\"fa fa-warning\"></i></div>\n"+
								"<h3 class=\"font-bold\">La pagina non e' stata trovata..</h3>\n"+
								
								"<div class=\"error-desc\">\n"+
								"Scusa, la pagina che stai cercando non e' stata trovata o non esiste piu'.<br/>\n"+
								"Clicca sul link qua sotto per tornare nella HomePage, grazie.<br/>\n"+
								"<div>\n"+
									"<a class=\" login-detail-panel-button btn\" href=\"/\">\n"+
										"<i class=\"fa fa-arrow-left\"></i>\n"+
										"Go back to Homepage		\n"+
									"</a>\n"+
								"</div>\n"+
								"</div>\n"+
							"</div>\n"+
					"</body>\n"+
				"</html>");
            });

        }
    }
}
