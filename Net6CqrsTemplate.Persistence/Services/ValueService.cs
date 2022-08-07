using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Persistence.Services
{
    public class ValueService : IValueService
    {

        private readonly IEnumerable<ValueItemDto> _items;


        public ValueService()
        {
            _items = new List<ValueItemDto>
            {
                new ValueItemDto
                {
                    Id = 1,
                    Name = "Value one"
                },

                new ValueItemDto
                {
                    Id = 2,
                    Name = "Value two"
                }
            };
        }

        public Task<ValueItemDto?> GetValueItem(int id)
        {

            var resultItem = _items.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(resultItem);
        }

        public IEnumerable<ValueItemDto> GetValueList()
        {
            return _items;
        }
    }
}
