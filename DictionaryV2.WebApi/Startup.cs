using DictionaryV2.Business.Abstract;
using DictionaryV2.Business.Concreate;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.DataAccess.Concreate.EntityFramework;
using DictionaryV2.DataAccess.Concreate.EntityFramework.Identity;
using DictionaryV2.Entity.Concreate.Identity;
using DictionaryV2.WebApi.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DictionaryV2.WebApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddCors();
            services.AddDbContext<DictionaryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityContext>()
                        .AddDefaultTokenProviders();

            services.AddTransient<IEngDictionaryService, EngDictionaryManager>();
            services.AddTransient<IEngDictionaryDal, EfEngDictionaryDal>();

            services.AddAuthentication()
                        .AddJwtBearer(options => {
                            options.TokenValidationParameters = new TokenValidationParameters {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = Configuration["Issuer"],
                                ValidAudience = Configuration["Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SigningKey"]))
                            };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            //provider'ı ekledik
            loggerFactory.AddProvider(new FileLogProvider());

            app.UseAuthentication();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "api/{controller=dictionary}/{action=get}");
            });
        }
    }
}
