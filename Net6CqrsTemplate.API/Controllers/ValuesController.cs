using MediatR;
using Microsoft.AspNetCore.Mvc;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Features.Value.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Net6CqrsTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ValueItemDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ValueItemDto?>>> Get()
        {
            var valueList= await _mediator.Send(new GetValueListRequest());

            if (valueList is null)
            {
                return BadRequest();
            }

            return Ok(valueList);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValueItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ValueItemDto?>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var valueItem = await _mediator.Send(new GetValueItemRequest { ValueItemId = id });

            return Ok(valueItem);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValueItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ValueItemDto> CreateValueItem([FromBody] ValueItemDto valueItemDto)
        {
            if (valueItemDto is null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
