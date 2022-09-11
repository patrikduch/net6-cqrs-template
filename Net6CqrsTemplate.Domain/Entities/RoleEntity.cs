namespace Net6CqrsTemplate.Domain.Entities;

/// <summary>
/// Domain object for pesisting all roles that can be associated with particular user.
/// </summary>
public class RoleEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
