using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Commands.CreateValueItem;
using Net6CqrsTemplate.Application.Mediator.ValueItem.Queries;

namespace Net6CqrsTemplate.Application.Usecases.ValueItem.Commands
{
    public class CreateValueItemCommandUsecase : IRequestHandler<CreateValueItemCommand, Result<ValueItemDto>>
    {
        private readonly IMediator _mediator;
        private readonly IValueWriter _valueWriter;

        public CreateValueItemCommandUsecase(IMediator mediator, IValueWriter valueWriter)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _valueWriter = valueWriter ?? throw new ArgumentNullException(nameof(valueWriter));
        }

        public async Task<Result<ValueItemDto>> Handle(CreateValueItemCommand request, CancellationToken cancellationToken)
        {

            var createValueItemCommandValidator = new CreateValueItemCommandValidator();
            var validationResult = await createValueItemCommandValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var validationException = new ValidationException(validationResult.Errors);
                return new Result<ValueItemDto>(validationException);
            }


            var valueDto = await _valueWriter.CreateNewValueItem(new InsertValueItemRequestDto(request.Name));

            if (valueDto is null) throw new Exception("Inserting new row into ValuesEntities failed.");

            var valueItemEntity = await _mediator.Send(new GetValueItemRequest
            {
                ValueItemId = valueDto.Id
            });


            return valueItemEntity;
        }
    }
}
