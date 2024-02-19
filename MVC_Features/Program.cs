namespace MVC_Features
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  // dependency injection
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            var app = builder.Build();


            // Middlewares
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
