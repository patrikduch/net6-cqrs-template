using MediatR;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Queries
{
    public class GetValueListRequest : IRequest<List<ValueItemDto>>
    {
    }
}
