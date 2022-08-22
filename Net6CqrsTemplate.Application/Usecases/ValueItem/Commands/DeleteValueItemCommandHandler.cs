using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Commands;

namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Commands
{
    public class DeleteValueItemCommandHandler : IRequestHandler<DeleteValueItemCommand, int?>
    {
        private readonly IValueWriter _valueWriter;

        public DeleteValueItemCommandHandler(IValueWriter valueWriter)
        {
            _valueWriter = valueWriter ?? throw new ArgumentNullException(nameof(valueWriter));

        }

        public async Task<int?> Handle(DeleteValueItemCommand request, CancellationToken cancellationToken)
        {
            var valueEntity = await _valueWriter.RemoveValueItem(request.ValueItemId);

            return valueEntity.Id;
        }
    }
}
