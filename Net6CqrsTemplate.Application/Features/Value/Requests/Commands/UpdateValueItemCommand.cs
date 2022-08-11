using MediatR;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Commands
{
    public class UpdateValueItemCommand : IRequest<int>
    {
        public UpdateValueItemRequestDto? UpdateValueItemRequestDto { get; set; }
    }
}
