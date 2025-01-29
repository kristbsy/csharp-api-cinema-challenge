using cinema.Data;
using cinema.Dto;
using cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema.Repository;

public class Repository : IRepository
{
    private CinemaContext db;

    public Repository(CinemaContext db)
    {
        this.db = db;
    }

    public async Task<Customer?> CreateCustomer(Customer customer)
    {
        var result = db.Add(customer);
        await db.SaveChangesAsync();
        return await db.Customers.FindAsync(result.Entity.Id);
    }

    public async Task<Movie?> CreateMovie(Movie movie)
    {
        var result = db.Add(movie);
        await db.SaveChangesAsync();
        return await db.Movies.FindAsync(result.Entity.Id);
    }

    public async Task<Screening?> CreateScreening(Screening screening)
    {
        var result = db.Add(screening);
        await db.SaveChangesAsync();
        return await db.Screenings.FindAsync(result.Entity.Id);
    }

    public async Task<Ticket?> CreateTicket(Ticket ticket)
    {
        var result = db.Add(ticket);
        await db.SaveChangesAsync();
        return await db.Tickets.FindAsync(result.Entity.Id);
    }

    public async Task<Customer?> DeleteCustomer(int id)
    {
        var found = await db.Customers.FindAsync(id);
        if (found == null)
        {
            return null;
        }
        db.Remove(found);
        await db.SaveChangesAsync();
        return found;
    }

    public async Task<Movie?> DeleteMovie(int id)
    {
        var found = await db.Movies.FindAsync(id);
        if (found == null)
        {
            return null;
        }
        db.Remove(found);
        await db.SaveChangesAsync();
        return found;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await db.Customers.ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        return await db.Movies.ToListAsync();
    }

    public async Task<IEnumerable<Screening>?> GetAllScreenings(int id)
    {
        return await db.Screenings.Where(s => s.MovieId == id).ToListAsync();
    }

    public async Task<IEnumerable<Ticket>?> GetAllTickets(int userId, int screeningId)
    {
        return await db
            .Tickets.Where(t => t.CustomerId == userId && t.ScreeningId == screeningId)
            .ToListAsync();
    }

    public async Task<Customer?> UpdateCustomer(int id, CustomerPartial customer)
    {
        var e = await db.Customers.FindAsync(id);
        if (e == null)
            return null;
        if (customer.Email != null)
            e!.Email = customer.Email;
        if (customer.Name != null)
            e!.Name = customer.Name;
        if (customer.Phone != null)
            e!.Phone = customer.Phone;
        e.Updated();
        await db.SaveChangesAsync();
        return e;
    }

    public async Task<Movie?> UpdateMovie(int id, MoviePartial movie)
    {
        var e = await db.Movies.FindAsync(id);
        if (e == null)
            return null;
        if (movie.Description != null)
            e.Description = movie.Description;
        if (movie.RuntimeMins != null)
            e.RuntimeMins = (int)movie.RuntimeMins;
        if (movie.Rating != null)
            e.Rating = movie.Rating;
        if (movie.Title != null)
            e.Title = movie.Title;
        e.Updated();
        await db.SaveChangesAsync();
        return e;
    }
}
