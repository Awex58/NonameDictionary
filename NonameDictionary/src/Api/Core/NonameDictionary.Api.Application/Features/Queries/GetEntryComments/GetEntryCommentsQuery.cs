using MediatR;
using NonameDictionary.Common.Models.Page;
using NonameDictionary.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Queries.GetEntryComments
{
    public class GetEntryCommentsQuery : BasePagedQuery,IRequest<PagedViewModel<GetEntryCommentsViewModel>>
    {
        public GetEntryCommentsQuery(Guid entryId, Guid? userId, int page, int pageSize) : base(page, pageSize)
        {
            EntryId = entryId;
            UserId = userId;
        }
        public Guid EntryId { get; set; } // gönderdiğimiz ıd kısmı
        public Guid? UserId { get; set; }
    }
}
