using MediatR;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Commands
{
    public class DeleteValueItemCommand : IRequest<int?>
    {
        public int ValueItemId { get; set; }
    }
}
