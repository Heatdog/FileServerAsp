using fileServer.Services.Databases;
using Microsoft.EntityFrameworkCore;

class Programm
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        if (connection == null)
        {
            Console.WriteLine("Connection did not specified");
            return;
        }

        builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(connection));

        builder.Services.AddControllersWithViews();
        
        var app = builder.Build();    

        app.MapControllers();

        app.Run();
    }
}