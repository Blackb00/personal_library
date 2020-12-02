using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Mocs;
using Personal_library_web.Data.Repository;
using Personal_library_web.Services.DropBox;
using System.Threading.Tasks;

namespace Personal_library_web
{
    public class Startup
    {
        public Startup()
        {
           
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorsInteractor, CAuthorsInteractor>();
            services.AddTransient<IBooksInteractor, CBooksInteractor>();
            services.AddTransient<ICategoriesInteractor, CCategoriesInteractor>();

            CDropBox appData = CDropBox.getInstance();
            services.AddSingleton<IRemoteStorage>(appData);

            services.AddMvc();
            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) => await Task.Run(()=>
            {
                IRemoteStorage library = context.RequestServices.GetService<IRemoteStorage>();
                library.LoadData();
            }));

        }
        
        
    }
}
