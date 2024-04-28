using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonameDictionary.Common.Models.RequestModels;

namespace NonameDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : BaseController
    {
        private readonly IMediator mediator;

        public EntryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateEntry")]
        public async Task<IActionResult> CreateEntry([FromForm] CreateEntryCommand command) //[FromBody]
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var res = await mediator.Send(command);

            return Ok(res);
        }
        [HttpPost]
        [Route("CreateEntryComment")]
        public async Task<IActionResult> CreateEntryComment([FromForm] CreateEntryCommentCommand command) //[FromBody]
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var res = await mediator.Send(command);

            return Ok(res);
        }
    }
}
