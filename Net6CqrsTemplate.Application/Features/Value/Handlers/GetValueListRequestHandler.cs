using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Features.Value.Requests.Queries;

namespace Net6CqrsTemplate.Application.Features.Value.Handlers
{
    public class GetValueListRequestHandler : IRequestHandler<GetValueListRequest, List<ValueItemDto>>
    {
        private readonly IValueService _valueService;

        public GetValueListRequestHandler(IValueService valueService)
        {
            _valueService = valueService ?? throw new ArgumentNullException(nameof(valueService));
        }

        public Task<List<ValueItemDto>> Handle(GetValueListRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_valueService.GetValueList().ToList()); 
        }
    }
}
