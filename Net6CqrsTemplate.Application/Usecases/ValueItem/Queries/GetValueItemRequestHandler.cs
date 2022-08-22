using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;

namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Queries
{
    public class GetValueItemRequestHandler : IRequestHandler<GetValueItemRequest, ValueItemDto?>
    {
        private readonly IValueService _valueService;

        public GetValueItemRequestHandler(IValueService valueService)
        {
            _valueService = valueService;
        }

        public Task<ValueItemDto?> Handle(GetValueItemRequest request, CancellationToken cancellationToken)
        {
            var resultEntity = _valueService.GetValueItem(request.ValueItemId);

            return resultEntity;
        }
    }
}
