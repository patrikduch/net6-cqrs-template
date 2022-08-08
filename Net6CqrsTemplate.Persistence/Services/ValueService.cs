using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Persistence.DbContexts;

namespace Net6CqrsTemplate.Persistence.Services
{
    public class ValueService : IValueService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ValueService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<ValueItemDto?> GetValueItem(int id)
        {
            var getValueItemQuery = _dbContext.ValueEntities.Where(v => v.Id == id);
            return await _mapper.ProjectTo<ValueItemDto>(getValueItemQuery).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ValueItemDto>> GetValueList()
        {
            var getValueListQuery = _dbContext.ValueEntities;
            return await _mapper.ProjectTo<ValueItemDto>(getValueListQuery).ToListAsync();
        }
    }
}
