using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

namespace TheaterBackend.Application.Services;

public class TicketService(ITicketRepo repo) : GenericService<Ticket>(repo), ITicketService;