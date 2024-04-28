using MediatR;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.EntryComment;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.EntryComment.CreateVote
{
    public class CreateEntryCommentVoteCommandHandler : IRequestHandler<CreateEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.VoteExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.CreateEntryCommentVoteQueueName, obj: new CreateEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreatedBy = request.CreatedBy,
                VoteType = request.VoteType,
            });
            return await Task.FromResult(true);
        }
    }
}
