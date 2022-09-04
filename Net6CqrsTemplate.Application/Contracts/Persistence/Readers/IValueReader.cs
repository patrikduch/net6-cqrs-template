using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Readers
{
    public interface IValueReader
    {
        Task<ValueEntity?> ReadValueById(int id);
        Task<IReadOnlyList<ValueEntity>> ReadAllValues();
    }
}
