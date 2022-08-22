using MediatR;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Mediator.ValueItem.Queries
{
    public class GetValueListRequest : IRequest<IEnumerable<ValueItemDto>>
    {
    }
}
