using Limakaz.Extensions;

namespace Limakaz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            ConfigureServices(builder);

            var app = builder.Build();

            ConfigureMiddleWareServices(app);

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {

            builder.Services.AddCustomService(builder.Configuration);
            builder.Services.AddMvc();
        }

        private static void ConfigureMiddleWareServices(WebApplication app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

        }


    }
}
