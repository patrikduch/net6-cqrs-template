using Microsoft.EntityFrameworkCore;
using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Readers;
using Net6CqrsTemplate.Application.Contracts.Persistence.Uow;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Persistence.Readers
{
    public class ValueReader : IValueReader
    {
        private readonly IValueRepository _valueRepository;
        private readonly IUnitOfWork uow;

        public ValueReader(IValueRepository valueRepository, IUnitOfWork uow)
        {
            _valueRepository = valueRepository ?? throw new ArgumentNullException(nameof(valueRepository));
            this.uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public Task<IReadOnlyList<ValueEntity>> ReadAllValues()
        {
            var res = _valueRepository.GetAll();
            return res;
        }

        public async Task<ValueEntity?> ReadValueById(int id)
        {

            var valueItemQuery = uow.Set<ValueEntity>().Where(v => v.Id == id);

            if (valueItemQuery is not null)
            {
                return await valueItemQuery.SingleOrDefaultAsync();
            }

            return null;
        }
    }
}
