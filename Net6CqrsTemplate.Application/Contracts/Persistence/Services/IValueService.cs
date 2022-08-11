using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Services
{
    public interface IValueService
    {
        Task<IEnumerable<ValueItemDto>> GetValueList();
        Task<ValueItemDto?> GetValueItem(int id);
        Task<ValueItemDto> CreateNewValues(InsertValueItemRequestDto newValueDto);
    }
}
