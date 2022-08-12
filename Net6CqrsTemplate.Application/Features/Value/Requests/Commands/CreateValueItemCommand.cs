using MediatR;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;

namespace Net6CqrsTemplate.Application.Features.Value.Requests.Commands
{
    public class CreateValueItemCommand : IRequest<int>
    {
        public InsertValueItemRequestDto? InsertValueItemRequestDto { get; set; }   
    }
}
