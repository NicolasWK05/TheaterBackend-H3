using Xunit;
using Moq;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;

public class PersonServiceTests
{
    [Fact]
    public async Task CreateAsync_HashesPassword()
    {
        var repoMock = new Mock<IPersonRepo>();
        Person? savedPerson = null;

        repoMock
            .Setup(r => r.AddAsync(It.IsAny<Person>()))
            .Callback<Person>(p => savedPerson = p)
            .Returns(Task.CompletedTask);

        var service = new PersonService(repoMock.Object);

        await service.CreateAsync(new TheaterBackend.Application.DTOs.PersonCreateDTO
        {
            Name = "Bob",
            Email = "bob@test.com",
            Password = "plaintext",
            PhoneNumber = "123"
        });

        Assert.NotNull(savedPerson);
        Assert.NotEqual("plaintext", savedPerson!.PasswordHash);
    }

    [Fact]
    public async Task GetAll_CallsRepository()
    {
        var repoMock = new Mock<IPersonRepo>();
        repoMock.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Person>());

        var service = new PersonService(repoMock.Object);

        await service.GetAllAsync();

        repoMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task Delete_CallsRepository()
    {
        var repoMock = new Mock<IPersonRepo>();
        repoMock.Setup(r => r.DeleteAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        var service = new PersonService(repoMock.Object);

        await service.DeleteAsync(1);

        repoMock.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
    }
}
