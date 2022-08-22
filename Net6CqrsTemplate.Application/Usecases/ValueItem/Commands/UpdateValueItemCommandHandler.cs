using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Commands;

namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Commands
{
    public class UpdateValueItemCommandHandler : IRequestHandler<UpdateValueItemCommand, int>
    {

        private readonly IValueWriter _valueWriter;

        public UpdateValueItemCommandHandler(IValueWriter valueWriter)
        {
            _valueWriter = valueWriter ?? throw new ArgumentNullException(nameof(valueWriter));
        }

        public async Task<int> Handle(UpdateValueItemCommand request, CancellationToken cancellationToken)
        {
            var resultEntity = await _valueWriter.UpdateValueItem(request.ValueItemId, request.UpdateValueItemRequestDto);
            if (resultEntity == null) throw new Exception("Update wasnt successfull.");

            return resultEntity.Id;
        }
    }
}
