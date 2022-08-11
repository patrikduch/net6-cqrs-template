using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Readers;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Persistence.Readers
{
    public class ValueReader : IValueReader
    {
        private readonly IValueRepository _valueRepository;

        public ValueReader(IValueRepository valueRepository)
        {
            _valueRepository = valueRepository ?? throw new ArgumentNullException(nameof(valueRepository));
        }

        public Task<IReadOnlyList<ValueEntity>> ReadAllValues()
        {
            var res = _valueRepository.GetAll();
            return res;
        }

        public Task<ValueEntity> ReadValueById(int id)
        {
            return _valueRepository.Get(id);
        }
    }
}
