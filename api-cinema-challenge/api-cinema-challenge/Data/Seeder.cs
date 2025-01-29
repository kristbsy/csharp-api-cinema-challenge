using cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data;

public static class Seeder
{
    public static async Task SeedCinemaApi(this WebApplication app)
    {
        using (var db = new CinemaContext())
        {
            if (!db.Customers.Any())
            {
                db.Add(
                    new Customer()
                    {
                        Name = "Nigel",
                        Email = "mail.com",
                        Phone = "333",
                    }
                );
                db.Add(
                    new Customer()
                    {
                        Name = "Dave",
                        Email = "mailed.com",
                        Phone = "111",
                    }
                );
                await db.SaveChangesAsync();
            }
            if (!db.Movies.Any())
            {
                db.Movies.Add(
                    new Movie
                    {
                        Title = "The: movie",
                        Rating = "999",
                        Description = "Its THE movie",
                        RuntimeMins = 15,
                    }
                );
                db.Movies.Add(
                    new Movie
                    {
                        Title = "The: movie; Second coming",
                        Rating = "999",
                        Description = "Its THE movie, but again",
                        RuntimeMins = 25,
                    }
                );
                await db.SaveChangesAsync();
            }
            if (!db.Screenings.Any())
            {
                db.Screenings.Add(
                    new Screening
                    {
                        Capacity = 33,
                        StartsAt = DateTime.UtcNow,
                        MovieId = 1,
                    }
                );
                db.Screenings.Add(
                    new Screening
                    {
                        Capacity = 73,
                        StartsAt = DateTime.UtcNow,
                        MovieId = 2,
                    }
                );
                //db.DeliveryDrivers.Add(new DeliveryDriver() { Name = "Driver 1" });
                //db.DeliveryDrivers.Add(new DeliveryDriver() { Name = "Driver 2" });
                await db.SaveChangesAsync();
            }
            if (!db.Tickets.Any())
            {
                db.Tickets.Add(
                    new Ticket
                    {
                        CustomerId = 1,
                        ScreeningId = 1,
                        NumSeats = 2,
                    }
                );
                db.Tickets.Add(
                    new Ticket
                    {
                        CustomerId = 2,
                        ScreeningId = 2,
                        NumSeats = 2,
                    }
                );
                await db.SaveChangesAsync();
            }
        }
    }
}
