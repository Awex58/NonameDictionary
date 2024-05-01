using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonameDictionary.Api.Application.Features.Commands.User.ConfirmEmail;
using NonameDictionary.Api.Application.Features.Queries.GetUserDetail;
using NonameDictionary.Common.Events.User;
using NonameDictionary.Common.Models.RequestModels;

namespace NonameDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserDetailQuery(id));

            return Ok(user);
        }

        [HttpGet]
        [Route("UserName/{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var user = await mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));

            return Ok(user);
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

        [HttpPost]
        [Route("ConfirmEMail")]
        public async Task<IActionResult> ConfirmEMail([FromForm] Guid Id) //[FromBody]
        {
            var res = await mediator.Send(new ConfirmEmailCommand() { ConfirmationId=Id });

            return Ok(res);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangeUserPasswordCommand command) //[FromBody]
        {
            if (!command.UserId.HasValue)
                command.UserId = UserId;

            var res = await mediator.Send(command);

            return Ok(res);
        }

    }
}
