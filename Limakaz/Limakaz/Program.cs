namespace Limakaz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.MapGet("/", () => "Hello World!");

            app.Run();
        }

        private static void ConfigureMiddleWareServices(WebApplication app)
        {
            app.UseStaticFiles();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

        }


    }
}
