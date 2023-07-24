namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<TRY.Models.user> user { get; set; }
    public DbSet<TRY.Models.TrainBooking> TrainBooking { get; set; }
    public DbSet<TRY.Models.train_details> train_details { get; set; }


}