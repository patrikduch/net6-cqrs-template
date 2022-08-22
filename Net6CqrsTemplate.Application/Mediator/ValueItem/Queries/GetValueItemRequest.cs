using MediatR;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Mediator.ValueItem.Queries
{
    public class GetValueItemRequest : IRequest<ValueItemDto?>
    {
        public int ValueItemId { get; set; }
    }
}
