using MediatR;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Commands
{
    public class UpdateValueItemCommand : IRequest<int>
    {
        public int ValueItemId { get; set; }
        public UpdateValueItemRequestDto? UpdateValueItemRequestDto { get; set; }
    }
}
