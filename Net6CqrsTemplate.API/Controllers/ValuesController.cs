using AutoMapper;
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

        private readonly IMapper mapper;
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        // GET: api/<ValuesController>
        [HttpGet]
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
