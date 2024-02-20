using Microsoft.EntityFrameworkCore;
using MVC_Features.Lifetime;
using MVC_Features.Repositories;

namespace MVC_Features
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  // dependency injection

            // 1) Framework Service
                 // built-in service // resgistered by default
            // 2) application Service
                   // built-in service  // registered by programmer
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            // 3) user defined service
            // 2- Register service (lifetime of object)

            // object per request
            //builder.Services.AddScoped<ImyService, myService>();

            // object per application
            //builder.Services.AddSingleton<ImyService, myService>();

            // object per injection
            builder.Services.AddTransient<ImyService, myService>();



            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();


            //3- resolve in runtime when creating object


            // inject DB
            builder.Services.AddDbContext<BanhaITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ITI"));
            });

            var app = builder.Build();


            // Middlewares
            #region user-defined
            // Excute Code  , call next middleware
            // app.use()
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("1- forward path middleware\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("5- backward path middleware 1\n");

            //});


            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2- forward path middleware\n");
            //   //if(false)   // short circuit
            //        await next.Invoke();
            //    await httpContext.Response.WriteAsync("4- backward path middleware 2\n");

            //});

            // Excute Code  , terminate request
            // app.run()
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3- terminate request\n");

            //});


            // Map request  for URL => Function
            //app.Map()


            //app.Map("/controller/action", () => { });
            #endregion

            #region Built-in Pipline
            //// Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // handling errors
            }
            app.UseStaticFiles();

            app.UseRouting();  // controller , action

            
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "TestRoute",
                pattern: "/LearnRoute/{action=Index}/test/{name:alpha:length(2,6)}",
                defaults: new
                {
                    controller="Routing"
                }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion


            app.Run();
        }
    }
}
