using AutoMapper;
using Net6CqrsTemplate.Application.Contracts.Persistence.Readers;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Persistence.Services
{
    public class ValueService : IValueService
    {
        private readonly IMapper _mapper;
        private readonly IValueReader _valueReader;
        private readonly IValueWriter _valueWriter;

        public ValueService(IMapper mapper, IValueReader valueReader, IValueWriter valueWriter)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _valueReader = valueReader ?? throw new ArgumentNullException(nameof(valueReader));
            _valueWriter = valueWriter ?? throw new ArgumentNullException(nameof(valueWriter));
        }

        public async Task<ValueItemDto> CreateNewValues(InsertValueItemRequestDto newValueDto)
        {
            var newValueItem = await _valueWriter.CreateNewValueItem(newValueDto);
            return _mapper.Map<ValueItemDto>(newValueItem);
        }

        public async Task<ValueItemDto?> GetValueItem(int id)
        {
            var getValueItemQuery = await _valueReader.ReadValueById(id);
            return _mapper.Map<ValueItemDto>(getValueItemQuery);
        }

        public async Task<IEnumerable<ValueItemDto>> GetValueList()
        {
            var valuesList = await _valueReader.ReadAllValues();
            return _mapper.Map<IEnumerable<ValueItemDto>>(valuesList);
        }
    }
}
