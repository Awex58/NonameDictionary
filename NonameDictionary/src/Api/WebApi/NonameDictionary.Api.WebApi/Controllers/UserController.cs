using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonameDictionary.Common.Models.RequestModels;

namespace NonameDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm]LoginUserCommand command) //[FromBody]
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command) //[FromBody]
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command) //[FromBody]
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }
    }
}
