using MediatR;

namespace Net6CqrsTemplate.Application.Mediator.ValueItem.Commands
{
    public class DeleteValueItemCommand : IRequest<int?>
    {
        public int ValueItemId { get; set; }
    }
}
