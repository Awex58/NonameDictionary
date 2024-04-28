using MediatR;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.Entry;
using NonameDictionary.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.Entry.DeleteFav
{
    public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.FavExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.DeleteEntryFavQueueName, obj: new DeleteEntryFavEvent()
            {
                EntryId = request.EntryId,
                CreatedBy = request.UserId
            });
            return await Task.FromResult(true);
        }
    }
}
