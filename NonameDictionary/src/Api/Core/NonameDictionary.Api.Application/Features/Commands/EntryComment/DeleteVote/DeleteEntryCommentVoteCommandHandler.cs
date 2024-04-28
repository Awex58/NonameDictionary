using MediatR;
using NonameDictionary.Api.Application.Features.Commands.Entry.DeleteVote;
using NonameDictionary.Common.Events.Entry;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonameDictionary.Common.Events.EntryComment;

namespace NonameDictionary.Api.Application.Features.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
          
                QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.VoteExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.DeleteEntryCommentVoteQueueName, obj: new DeleteEntryCommentVoteEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId
                });
                return await Task.FromResult(true);
         }
        
    }
}
