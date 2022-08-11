using Net6CqrsTemplate.Domain.Entities.Common;

namespace Net6CqrsTemplate.Domain.Entities
{
    public class ValueEntity : BaseDomainEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
