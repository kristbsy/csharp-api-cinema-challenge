using cinema.Dto;
using cinema.Models;

namespace cinema.Repository;

public interface IRepository
{
    Task<Customer?> CreateCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomers();
    Task<Customer?> UpdateCustomer(int id, CustomerPartial customer); // TODO: change to optional fields customer
    Task<Customer?> DeleteCustomer(int id);

    Task<Movie?> CreateMovie(Movie movie);
    Task<IEnumerable<Movie>> GetAllMovies();
    Task<Movie?> UpdateMovie(int id, MoviePartial movie); // TODO: change to optional fields
    Task<Movie?> DeleteMovie(int id);

    Task<Screening?> CreateScreening(Screening screening);
    Task<IEnumerable<Screening>?> GetAllScreenings(int id);

    Task<Ticket?> CreateTicket(Ticket ticket);
    Task<IEnumerable<Ticket>?> GetAllTickets(int userId, int screeningId);
}
