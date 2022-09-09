namespace Net6CqrsTemplate.Tests.UseCases.ValueItem.Queries;

using AutoMapper;
using FluentAssertions;
using Moq;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;
using Net6CqrsTemplate.Application.Profiles;
using Net6CqrsTemplate.Application.Usecases.ValueItem.Queries;

/// <summary>
/// Test case for CQRS logic of <seealso cref="GetValueItemQueryUsecase"/>
/// </summary>
public class GetValueItemQueryUseCaseTest
{
    private IMapper _mapper;
    private Mock<IValueService> _mockValueService;

    public GetValueItemQueryUseCaseTest()
    {

        _mockValueService = new Mock<IValueService>();


        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile<AutomapperProfile>();

        });

        _mapper = mapperConfig.CreateMapper();

        var valueItemDto = new ValueItemDto
        {
            Id = 1,
            Name = "TestName"
        };
        _mockValueService.Setup(ms => ms.GetValueItem(1)).ReturnsAsync(valueItemDto);
    }

    [Fact]
    public async Task Test()
    {
        // Arrange
        var handler = new GetValueItemQueryUsecase(_mockValueService.Object);

        var usecaseRequest = new GetValueItemRequest
        {
            ValueItemId = 1
        };

        // Act
        var result = await handler.Handle(usecaseRequest, CancellationToken.None);


        // Assert
        result.Should().NotBeNull();
    }
}
