using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Features.Value.Requests.Commands;

namespace Net6CqrsTemplate.Application.Features.Value.Handlers.Commands
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
            var resultEntity = await _valueWriter.UpdateValueItem(request.UpdateValueItemRequestDto);
            if (resultEntity == null) throw new Exception("Update wasnt successfull.");

            return resultEntity.Id;
        }
    }
}
