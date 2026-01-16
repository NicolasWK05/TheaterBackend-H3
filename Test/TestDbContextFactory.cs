using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using TheaterBackend.Infrastructure;

public static class TestDbContextFactory
{
    public static DatabaseContext Create()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new DatabaseContext(options);
    }
}
