﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Common.Events.Entry
{
    public class DeleteEntryVoteEvent
    {
        public Guid EntryId { get; set; }
        public Guid CreatedBy { get; set;}
    }
}
