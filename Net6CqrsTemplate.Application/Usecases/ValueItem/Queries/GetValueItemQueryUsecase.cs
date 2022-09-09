namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Queries;

using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;

/// <summary>
/// Bussiness logic for retrieving ValueItem by unique identifier.
/// </summary>
public class GetValueItemQueryUsecase : IRequestHandler<GetValueItemRequest, ValueItemDto?>
{
    private readonly IValueService _valueService;

    public GetValueItemQueryUsecase(IValueService valueService)
    {
        _valueService = valueService;
    }

    /// <summary>
    /// Interceptor that handles GetValueItemRequest request via MediatR pipeline.
    /// </summary>
    /// <param name="request">Intercepting MediatR request.</param>
    /// <param name="cancellationToken">Cancelation token object.</param>
    public Task<ValueItemDto?> Handle(GetValueItemRequest request, CancellationToken cancellationToken)
    {
        var resultEntity = _valueService.GetValueItem(request.ValueItemId);

        return resultEntity;
    }
}
