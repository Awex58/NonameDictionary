using MediatR;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.Entry;
using NonameDictionary.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.Entry.DeleteVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.VoteExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.DeleteEntryVoteQueueName, obj: new DeleteEntryVoteEvent(){
                EntryId = request.EntryId,
                CreatedBy = request.UserId
            });
            return await Task.FromResult(true);
        }
    }
}
