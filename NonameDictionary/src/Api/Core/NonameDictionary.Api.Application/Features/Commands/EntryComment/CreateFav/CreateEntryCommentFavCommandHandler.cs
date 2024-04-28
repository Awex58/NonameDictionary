using MediatR;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.EntryComment;
using NonameDictionary.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntryCommentFavCommandHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.FavExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.CreateEntryCommentFavQueueName,
                obj: new CreateEntryCommentFavEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId
                });

            return await Task.FromResult(true);
        }
    }
}
