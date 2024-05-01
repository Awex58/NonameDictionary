using MediatR;
using NonameDictionary.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Queries.GetEntryDetail
{
    public class GetEntryDetailQuery:IRequest<GetEntryDetailViewModel>
    {
        public Guid EntryId { get; set; }
        public Guid? UserId { get; set; }

        public GetEntryDetailQuery(Guid entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }
    }
}
