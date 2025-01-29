namespace cinema.Utils;

using AutoMapper;
using cinema.Dto;
using cinema.Models;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CustomerPostDto, Customer>();
        CreateMap<MoviePostDto, Movie>();
        CreateMap<ScreeningPost, Screening>();
        CreateMap<TicketPostDto, Ticket>();
    }
}
