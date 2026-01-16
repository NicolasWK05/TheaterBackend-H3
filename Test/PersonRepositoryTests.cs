using Xunit;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

public class PersonRepositoryTests
{
    [Fact]
    public async Task AddPerson_PersistsToDatabase()
    {
        var ctx = TestDbContextFactory.Create();
        var repo = new PersonRepository(ctx);

        var person = new Person
        {
            Name = "Test",
            Email = "test@test.com",
            PhoneNumber = "12345678",
            PasswordHash = "hashed-password"
        };


        await repo.AddAsync(person);

        Assert.Equal(1, ctx.Persons.Count());
    }

    [Fact]
    public async Task GetById_ReturnsCorrectPerson()
    {
        var ctx = TestDbContextFactory.Create();
        var repo = new PersonRepository(ctx);

        var person = new Person { Name = "Alice", Email = "alice@example.com", PhoneNumber = "12345678", PasswordHash = "hashed-password" };
        await repo.AddAsync(person);

        var result = await repo.GetByIdAsync(person.Id);

        Assert.NotNull(result);
        Assert.Equal("Alice", result!.Name);
    }

    [Fact]
    public async Task Delete_RemovesEntity()
    {
        var ctx = TestDbContextFactory.Create();
        var repo = new PersonRepository(ctx);

        var person = new Person { Name = "DeleteMe", Email = "delete@example.com", PhoneNumber = "12345678", PasswordHash = "hashed-password" };
        await repo.AddAsync(person);

        await repo.DeleteAsync(person.Id);

        Assert.Empty(ctx.Persons);
    }

    [Fact]
    public async Task Update_ChangesPersist()
    {
        var ctx = TestDbContextFactory.Create();
        var repo = new PersonRepository(ctx);

        var person = new Person { Name = "Old", Email = "old@example.com", PhoneNumber = "12345678", PasswordHash = "hashed-password" };
        await repo.AddAsync(person);

        person.Name = "New";
        await repo.UpdateAsync(person);

        Assert.Equal("New", ctx.Persons.First().Name);
    }
}
