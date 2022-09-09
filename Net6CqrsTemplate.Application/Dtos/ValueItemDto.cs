namespace Net6CqrsTemplate.Application.Dtos;

public record ValueItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}