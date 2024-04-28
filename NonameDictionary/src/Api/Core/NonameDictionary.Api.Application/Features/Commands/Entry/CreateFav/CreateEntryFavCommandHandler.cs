using MediatR;
using NonameDictionary.Common.Events.EntryComment;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonameDictionary.Common.Events.Entry;

namespace NonameDictionary.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.FavExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.CreateEntryFavQueueName,
                obj: new CreateEntryFavEvent()
                {
                    EntryId = request.EntryId.Value,
                    CreatedBy = request.UserId.Value
                    
                });

            return await Task.FromResult(true);
        }
    }

}
