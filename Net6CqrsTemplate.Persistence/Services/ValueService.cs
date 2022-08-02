using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;

namespace Net6CqrsTemplate.Persistence.Services
{
    public class ValueService : IValueService
    {
        public IEnumerable<ValueItemDto> GetValueList()
        {
            return new List<ValueItemDto>()
            {
                new ValueItemDto
                {
                    Id = 1,
                    Name = "Value one"
                }
            };
        }
    }
}
