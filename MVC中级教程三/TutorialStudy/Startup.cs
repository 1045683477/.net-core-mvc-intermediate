using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TutorialStudy.Data;
using TutorialStudy.Model;
using TutorialStudy.Services;

namespace TutorialStudy
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
            {
                    //options.UseSqlServer(connectionString);
                    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
             });

            /*Transient：每一次GetService都会创建一个新的实例
                Scoped：在同一个Scope内只初始化一个实例 ，可以理解为（ 每一个request级别只创建一个实例，同一个http request会在一个 scope内）
                Singleton：整个应用程序生命周期内只创建一个实例 */

            //services.AddScoped<IRepository<Student>, InMemoryRepository>();
            //services.AddSingleton<IRepository<Student>, InMemoryRepository>();
            services.AddScoped<IRepository<Student>, EfCoreRepository>();//这里不能用AddSingleton，会发生多线程的问题，这里是每次http请求生成一个实例
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc(routes => { routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"); });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
