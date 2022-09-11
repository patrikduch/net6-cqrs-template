
namespace Net6CqrsTemplate.Persistence.Configurations.Entities;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net6CqrsTemplate.Domain.Entities;


/// <summary>
/// Entity persistence configuration for RoleEntity.
/// </summary>
public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Role");

        builder.Property(r => r.Id).HasColumnName("Id");
        builder.Property(r => r.Name).HasColumnName("Name");
        builder.HasKey(r => r.Id);
    }
}
