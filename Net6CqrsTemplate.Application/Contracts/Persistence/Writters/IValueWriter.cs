using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Writters
{
    public interface IValueWriter
    {
        Task<ValueItemDto> CreateNewValueItem(InsertValueItemRequestDto newValueItem);
    }
}
