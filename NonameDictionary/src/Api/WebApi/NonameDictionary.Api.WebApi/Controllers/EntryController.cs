using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonameDictionary.Api.Application.Features.Queries.GetEntries;
using NonameDictionary.Api.Application.Features.Queries.GetMainPageEntites;
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


        [HttpGet]
        public async Task<IActionResult> GetEntries([FromQuery]GetEntriesQuery query)
        {
            var entries = await mediator.Send(query);

            return Ok(entries);
        }

        [HttpGet]
        [Route("MainPageEntries")]

        public async Task<IActionResult> GetMainPageEntries([FromQuery] int page,int pageSize)
        {
            var entries = await mediator.Send(new GetMainPageEntriesQuery(UserId,page,pageSize));

            return Ok(entries);
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
