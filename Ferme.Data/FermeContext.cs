using System.Configuration;
using Ferme.Data.Map;
using Ferme.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ferme.Data;

public class FermeContext : DbContext
{
    private readonly IConfiguration _configuration;

    public FermeContext(DbContextOptions<FermeContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<CaisseLite> CaisseLite { get; set; }
    public virtual DbSet<BasePrice> BasePrice { get; set; }
    public virtual DbSet<Payment> Payment { get; set; }
    public virtual DbSet<PLU> PLU { get; set; }
    public virtual DbSet<Registration> Registration { get; set; }
    public virtual DbSet<VAT> VAT { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        Console.WriteLine();
        var bdd = _configuration.GetSection("bddType").Value;
        if (bdd == "postGre")
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        else
            throw new Exception("You should not be here");
        //    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyAFermeContextConfiguration(modelBuilder);
    }

    private static void ApplyAFermeContextConfiguration(ModelBuilder modelBuilder)
    {
        // Admin
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<CaisseLite>());
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<BasePrice>());
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<Payment>());
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<PLU>());
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<Registration>());
        modelBuilder.ApplyConfiguration(new DefaultBuilderEntityMap<VAT>());
    }

}