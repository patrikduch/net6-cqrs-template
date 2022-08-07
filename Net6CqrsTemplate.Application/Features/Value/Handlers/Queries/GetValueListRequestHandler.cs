using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Features.Value.Requests.Queries;

namespace Net6CqrsTemplate.Application.Features.Value.Handlers.Queries
{
    public class GetValueListRequestHandler : IRequestHandler<GetValueListRequest, IEnumerable<ValueItemDto>>
    {
        private readonly IValueService _valueService;

        public GetValueListRequestHandler(IValueService valueService)
        {
            _valueService = valueService ?? throw new ArgumentNullException(nameof(valueService));
        }

        public Task<IEnumerable<ValueItemDto>> Handle(GetValueListRequest request, CancellationToken cancellationToken)
        {

            var resultList = _valueService.GetValueList();

            return Task.FromResult(resultList);
        }
    }
}
