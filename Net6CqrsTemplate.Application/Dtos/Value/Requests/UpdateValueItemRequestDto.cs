namespace Net6CqrsTemplate.Application.Dtos.Value.Requests
{
    public class UpdateValueItemRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
