using MediatR;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Queries
{
    public class GetValueItemRequest : IRequest<ValueItemDto>
    {
        public int ValueItemId { get; set; }
    }
}
