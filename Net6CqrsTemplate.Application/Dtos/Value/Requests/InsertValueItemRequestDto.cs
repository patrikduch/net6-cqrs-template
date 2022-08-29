namespace Net6CqrsTemplate.Application.Dtos.Value.Requests;

/// <summary>
/// Request DTO for creating new value item.
/// </summary>
/// <param name="Name">Name propety that will be added to the database.</param>
public record InsertValueItemRequestDto(string Name);