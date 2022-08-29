namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Queries;

using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;

public class GetValueItemQueryUsecase : IRequestHandler<GetValueItemRequest, ValueItemDto?>
{
    private readonly IValueService _valueService;

    public GetValueItemQueryUsecase(IValueService valueService)
    {
        _valueService = valueService;
    }

    public Task<ValueItemDto?> Handle(GetValueItemRequest request, CancellationToken cancellationToken)
    {
        var resultEntity = _valueService.GetValueItem(request.ValueItemId);

        return resultEntity;
    }
}
