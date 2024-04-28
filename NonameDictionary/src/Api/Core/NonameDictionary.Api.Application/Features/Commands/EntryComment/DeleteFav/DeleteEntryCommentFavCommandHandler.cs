using MediatR;
using NonameDictionary.Common.Events.Entry;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonameDictionary.Common.Events.EntryComment;

namespace NonameDictionary.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.FavExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.DeleteEntryCommentFavQueueName,
                obj: new DeleteEntryCommentFavEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreatedBy = request.UserId
            });
            return await Task.FromResult(true);
        }
    }
}
