using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class TicketService(ITicketRepo repo, IScreeningRepo screeningRepo) : GenericService<Ticket>(repo), ITicketService
{
    public async Task<TicketReadDTO> CreateAsync(
        int personId,
        TicketCreateDTO dto)
    {
        var screening = await screeningRepo.GetByIdAsync(dto.ScreeningId);

        var ticket = new Ticket
        {
            Screening = screening!,
            PersonId = personId,
            SeatRow = dto.SeatRow,
            SeatColumn = dto.SeatColumn,
            Price = 120m
        };

        await repo.AddAsync(ticket);

        return new TicketReadDTO
        {
            Id = ticket.Id,
            FilmTitle = screening!.Film.Title,
            StartTime = screening.StartTime,
            SeatRow = ticket.SeatRow,
            SeatColumn = ticket.SeatColumn,
            Price = ticket.Price
        };
    }

    public Task<IEnumerable<Ticket>> GetByPersonAsync(int personId)
    {
        return repo.GetByPersonAsync(personId);
    }
}
