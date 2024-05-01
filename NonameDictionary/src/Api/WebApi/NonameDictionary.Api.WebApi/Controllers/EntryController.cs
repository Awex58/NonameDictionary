﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonameDictionary.Api.Application.Features.Queries.GetEntries;
using NonameDictionary.Api.Application.Features.Queries.GetEntryComments;
using NonameDictionary.Api.Application.Features.Queries.GetEntryDetail;
using NonameDictionary.Api.Application.Features.Queries.GetMainPageEntites;
using NonameDictionary.Api.Application.Features.Queries.GetUserEntries;
using NonameDictionary.Common.Models.Queries;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetEntryDetailQuery(id, UserId));

            return Ok(result);
        }


        [HttpGet]
        [Route("Comments/{id}")]
        public async Task<IActionResult> GetEntryComments(Guid id, int page, int pageSize)
        {
            var result = await mediator.Send(new GetEntryCommentsQuery(id, UserId, page, pageSize));

            return Ok(result);
        }

        [HttpGet]
        [Route("UserEntries")]
        [Authorize]
        public async Task<IActionResult> GetUserEntries(string userName, Guid userId, int page, int pageSize)
        {
            if (userId == Guid.Empty && string.IsNullOrEmpty(userName))
                userId = UserId.Value;

            var result = await mediator.Send(new GetUserEntriesQuery(userId, userName, page, pageSize));

            return Ok(result);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchEntryQuery query)
        {
            var result = await mediator.Send(query);

            return Ok(result);
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
