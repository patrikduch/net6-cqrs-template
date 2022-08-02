using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Services
{
    public interface IValueService
    {
        IEnumerable<ValueItemDto> GetValueList();
    }
}
