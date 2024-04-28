using MediatR;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.Entry;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.VoteExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.CreateEntryFavQueueName, obj: new CreateEntryVoteEvent()
            {
                EntryId = request.EntryId,
                CreatedBy = request.CreatedBy,
                VoteType = request.VoteType,
            });
            return await Task.FromResult(true);
        }
    }
}
