using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Features.Value.Requests.Commands;

namespace Net6CqrsTemplate.Application.Features.Value.Handlers.Commands
{
    public class CreateValueItemCommandHandler : IRequestHandler<CreateValueItemCommand, int>
    {
        private readonly IValueWriter _valueWriter;

        public CreateValueItemCommandHandler(IValueWriter valueWriter)
        {
            _valueWriter = valueWriter ?? throw new ArgumentNullException(nameof(valueWriter));
        }

        public async Task<int> Handle(CreateValueItemCommand request, CancellationToken cancellationToken)
        {
            var valueDto = await _valueWriter.CreateNewValueItem(request.InsertValueItemRequestDto);

            if (valueDto is null) throw new Exception("Inserting new row into ValuesEntities failed.");

            return valueDto.Id;
        }
    }
}
