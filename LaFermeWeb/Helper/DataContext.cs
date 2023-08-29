using Microsoft.EntityFrameworkCore;

namespace LaFermeWeb.Helper;

public class DataContext : DbContext
{
	protected readonly IConfiguration Configuration;

	public DataContext(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
	}

	public DbSet<PLU>? PLUs { get; set; }
}


