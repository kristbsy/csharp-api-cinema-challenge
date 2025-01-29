using cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data;

public class CinemaContext : DbContext
{
    private string connectionString;

    public CinemaContext()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        connectionString = configuration.GetValue<string>(
            "ConnectionStrings:DefaultConnectionString"
        )!;
        this.Database.EnsureCreated();
        this.Database.SetConnectionString(connectionString);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder m)
    {
        m.Entity<Customer>().HasKey(c => c.Id);
        m.Entity<Customer>().HasMany(c => c.Tickets).WithOne().HasForeignKey(t => t.CustomerId);

        m.Entity<Movie>().HasKey(c => c.Id);
        m.Entity<Movie>()
            .HasMany(c => c.Screenings)
            .WithOne(s => s.Movie)
            .HasForeignKey(s => s.MovieId);

        m.Entity<Screening>().HasKey(c => c.Id);
        m.Entity<Screening>()
            .HasMany(s => s.Tickets)
            .WithOne(t => t.Screening)
            .HasForeignKey(t => t.ScreeningId);

        m.Entity<Ticket>().HasKey(c => c.Id);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
