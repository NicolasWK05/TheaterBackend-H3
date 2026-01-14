using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

namespace TheaterBackend.Application.Services;

public class ScreeningService(IScreeningRepo repo) : GenericService<Screening>(repo), IScreeningService {}