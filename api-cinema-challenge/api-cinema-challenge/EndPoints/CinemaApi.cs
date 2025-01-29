using AutoMapper;
using cinema.Dto;
using cinema.Models;
using cinema.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api;

public static class CinemaApi
{
    public static void ConfigurePizzaShopApi(this WebApplication app)
    {
        //customers
        app.MapPost("/customers", CreateCustomer);
        app.MapGet("/customers", GetAllCustomers);
        app.MapPut("/customers/{id}", UpdateCustomer);
        app.MapDelete("/customers/{id}", DeleteCustomer);

        // movies
        app.MapPost("/movies", CreateMovie);
        app.MapGet("/movies", GetAllMovies);
        app.MapPut("/movies/{id}", UpdateMovie);
        app.MapDelete("/movies/{id}", DeleteMovie);

        // screenings
        app.MapPost("/movies/{id}/screenings", CreateScreening);
        app.MapGet("/movies/{id}/screenings", GetAllScreenings);

        //tickets
        app.MapPost("/customers/{customerId}/screenings/{screeningId}", CreateTicket);
        app.MapGet("/customers/{customerId}/screenings/{screeningId}", GetTickets);
    }

    public static async Task<Ok<DataWrapper<Customer?>>> CreateCustomer(
        IRepository repo,
        IMapper mapper,
        CustomerPostDto customer
    )
    {
        var result = await repo.CreateCustomer(mapper.Map<Customer>(customer));
        return WrapGet(result);
    }

    public static async Task<Ok<DataWrapper<IEnumerable<Customer>>>> GetAllCustomers(
        IRepository repo
    )
    {
        return Wrap(await repo.GetAllCustomers());
    }

    public static async Task<Ok<DataWrapper<Customer?>>> UpdateCustomer(
        IRepository repo,
        int id,
        CustomerPartial customer
    )
    {
        return WrapGet(await repo.UpdateCustomer(id, customer));
    }

    public static async Task<Ok<DataWrapper<Customer?>>> DeleteCustomer(IRepository repo, int id)
    {
        return WrapGet(await repo.DeleteCustomer(id));
    }

    public static async Task<Ok<DataWrapper<Movie?>>> CreateMovie(
        IRepository repo,
        IMapper mapper,
        MoviePostDto movie
    )
    {
        // TODO: create screenings also;
        foreach (var s in movie.Screenings)
        {
            await repo.CreateScreening(mapper.Map<Screening>(s));
        }
        return WrapGet(await repo.CreateMovie(mapper.Map<Movie>(movie)));
    }

    public static async Task<Ok<DataWrapper<IEnumerable<Movie>>>> GetAllMovies(IRepository repo)
    {
        return Wrap(await repo.GetAllMovies());
    }

    public static async Task<Ok<DataWrapper<Movie?>>> UpdateMovie(
        IRepository repo,
        int id,
        MoviePartial movie
    )
    {
        return WrapGet(await repo.UpdateMovie(id, movie));
    }

    public static async Task<Ok<DataWrapper<Movie?>>> DeleteMovie(IRepository repo, int id)
    {
        return WrapGet(await repo.DeleteMovie(id));
    }

    public static async Task<Ok<DataWrapper<Screening?>>> CreateScreening(
        IRepository repo,
        int movieId,
        ScreeningPost screening
    )
    {
        var s = new Screening()
        {
            StartsAt = screening.StartsAt,
            Capacity = screening.Capacity,
            MovieId = movieId,
        };
        return WrapGet(await repo.CreateScreening(s));
    }

    public static async Task<Ok<DataWrapper<IEnumerable<Screening>?>>> GetAllScreenings(
        IRepository repo,
        int movieId
    )
    {
        return WrapGet(await repo.GetAllScreenings(movieId));
    }

    public static async Task<Ok<DataWrapper<Ticket?>>> CreateTicket(
        IRepository repo,
        int customerId,
        int screeningId,
        TicketPostDto ticket
    )
    {
        var t = new Ticket
        {
            NumSeats = ticket.NumSeats,
            CustomerId = customerId,
            ScreeningId = screeningId,
        };
        return WrapGet(await repo.CreateTicket(t));
    }

    public static async Task<Ok<DataWrapper<IEnumerable<Ticket>?>>> GetTickets(
        IRepository repo,
        int customerId,
        int screeningId
    )
    {
        return WrapGet(await repo.GetAllTickets(customerId, screeningId));
    }

    private static Ok<DataWrapper<T>> Wrap<T>(T o)
    {
        return TypedResults.Ok(new DataWrapper<T>(o));
    }

    private static Ok<DataWrapper<T?>> WrapGet<T>(T o)
        where T : class?
    {
        if (o is null)
        {
            var wrapped = new DataWrapper<T?> { Status = Status.notFound, Data = null };
            return TypedResults.Ok(wrapped);
        }
        return TypedResults.Ok(new DataWrapper<T?>(o));
    }
}
