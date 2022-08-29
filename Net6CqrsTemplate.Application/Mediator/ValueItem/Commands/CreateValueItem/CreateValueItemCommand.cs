namespace Net6CqrsTemplate.Application.Mediator.ValueItem.Commands.CreateValueItem;

using LanguageExt.Common;
using MediatR;
using Net6CqrsTemplate.Application.Dtos;


/// <summary>
/// CQRS command contract for inserting new value into ValueItem entity.
/// </summary>
public class CreateValueItemCommand : IRequest<Result<ValueItemDto>>
{
    public string Name { get; set; } = string.Empty;
}