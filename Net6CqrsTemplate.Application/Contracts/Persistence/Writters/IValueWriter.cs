using Net6CqrsTemplate.Application.Dtos.Value.Requests;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Writters
{
    public interface IValueWriter
    {
        Task<ValueEntity?> CreateNewValueItem(InsertValueItemRequestDto newValueItem);
        Task<ValueEntity?> UpdateValueItem(int valueItemId, UpdateValueItemRequestDto? newValueItem);
        Task<ValueEntity> RemoveValueItem(int valueItemId);
    }
}
