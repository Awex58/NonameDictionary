using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Common.Events.EntryComment
{
    public class DeleteEntryCommentVoteEvent
    {
        public Guid CreatedBy { get; set; }
        public Guid EntryCommentId { get; set; }
    }
}
