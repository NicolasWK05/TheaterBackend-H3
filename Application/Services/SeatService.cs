using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

namespace TheaterBackend.Application.Services;

public class SeatService(ISeatRepo repo) : GenericService<Seat>(repo), ISeatService {}