using Xunit;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

public class ScreenRepositoryTests
{
    [Fact]
    public async Task Screen_CanReferenceTheater()
    {
        var ctx = TestDbContextFactory.Create();
        var theater = new Theater { Name = "Main", Address = "Address" };
        ctx.Theaters.Add(theater);
        await ctx.SaveChangesAsync();

        var repo = new ScreenRepo(ctx);

        var screen = new Screen
        {
            Name = "Screen 1",
            TheaterId = theater.Id
        };

        await repo.AddAsync(screen);

        Assert.Equal(theater.Id, ctx.Screens.First().TheaterId);
    }

    [Fact]
    public async Task Theater_LoadsScreens()
    {
        var ctx = TestDbContextFactory.Create();

        var theater = new Theater { Name = "T", Address = "Address" };
        ctx.Theaters.Add(theater);
        await ctx.SaveChangesAsync();

        ctx.Screens.Add(new Screen { Name = "S1", TheaterId = theater.Id });
        ctx.Screens.Add(new Screen { Name = "S2", TheaterId = theater.Id });
        await ctx.SaveChangesAsync();

        var repo = new TheaterRepo(ctx);
        var result = await repo.GetAllAsync();

        Assert.Equal(2, result.First().Screens.Count);
    }
}
