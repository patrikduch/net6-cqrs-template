using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Persistence.Writers
{
    public class ValueWriter : IValueWriter
    {
        public Task<ValueItemDto> CreateNewValueItem(InsertValueItemRequestDto newValueItem)
        {
            throw new NotImplementedException();
        }
    }
}
