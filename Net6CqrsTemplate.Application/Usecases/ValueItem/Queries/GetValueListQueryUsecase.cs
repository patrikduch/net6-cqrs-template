namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Queries;

using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;

public class GetValueListQueryUsecase : IRequestHandler<GetValueListRequest, IEnumerable<ValueItemDto>>
{
    private readonly IValueService _valueService;

    public GetValueListQueryUsecase(IValueService valueService)
    {
        _valueService = valueService ?? throw new ArgumentNullException(nameof(valueService));
    }

    public Task<IEnumerable<ValueItemDto>> Handle(GetValueListRequest request, CancellationToken cancellationToken)
    {
        return _valueService.GetValueList();
    }
}
