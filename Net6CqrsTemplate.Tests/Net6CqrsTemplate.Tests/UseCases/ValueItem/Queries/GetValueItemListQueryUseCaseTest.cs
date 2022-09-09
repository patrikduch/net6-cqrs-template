namespace Net6CqrsTemplate.Tests.UseCases.ValueItem.Queries;

using AutoMapper;
using FluentAssertions;
using Moq;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;
using Net6CqrsTemplate.Application.Profiles;
using Net6CqrsTemplate.Application.Usecases.ValueItem.Queries;

public class GetValueItemListQueryUseCaseTest
{
    private IMapper _mapper;
    private Mock<IValueService> _mockValueService;

    public GetValueItemListQueryUseCaseTest()
    {
        _mockValueService = new Mock<IValueService>();


        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile<AutomapperProfile>();

        });

        _mapper = mapperConfig.CreateMapper();

        var valueItemList = new List<ValueItemDto>
        {
            new ValueItemDto
            {
                Id = 1,
                Name = "TestName"
            },

            new ValueItemDto
            {
                Id = 2,
                Name ="Another TestName"
            }
        };

        
        _mockValueService.Setup(ms => ms.GetValueList()).ReturnsAsync(valueItemList);

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
