﻿using MediatR;
using NonameDictionary.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Common.Models.RequestModels
{
    public class CreateEntryVoteCommand:IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public Guid CreatedBy { get; set; }
        public VoteType VoteType { get; set; }
    }
}
