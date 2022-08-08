using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Services
{
    public interface IValueService
    {
        Task<IEnumerable<ValueItemDto>> GetValueList();
        Task<ValueItemDto?> GetValueItem(int id);
    }
}
