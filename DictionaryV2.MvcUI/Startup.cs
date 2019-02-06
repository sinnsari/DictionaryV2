using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DictionaryV2.Business.Abstract;
using DictionaryV2.Business.Concreate;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.DataAccess.Concreate.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DictionaryV2.MvcUI {
    public class Startup {

        public IConfiguration Configuration;
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            services.AddMvc();
            services.AddDbContext<DictionaryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DictionaryV2.MvcUI")));

            //RegisterAutofacServices();

            services.AddTransient<IEngDictionaryDal, EfEngDictionaryDal>();
            services.AddTransient<IEngDictionaryService, EngDictionaryManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            //if (env.IsDevelopment()) {

            //}
            //else {
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseDeveloperExceptionPage();

            app.UseMvc(routes => routes.MapRoute(
                name:"default",
                template:"{controller=Home}/{action=Index}/{id?}")
            );

            app.UseStaticFiles();
        }

        //private void RegisterAutofacServices() {

        //    var builder = new ContainerBuilder();

        //    builder.RegisterControllers(Assembly.GetExecutingAssembly());
        //    builder.RegisterType<EfEngDictionaryDal>().As<IEngDictionaryDal>();
        //    builder.RegisterType<EngDictionaryManager>().As<IEngDictionaryService>();

        //    IContainer container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        //}
    }
}
