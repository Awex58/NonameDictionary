﻿using MediatR;
using NonameDictionary.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Queries.GetEntries
{
    public class GetEntriesQuery:IRequest<List<GetEntriesViewModel>>
    {
        public bool TodaysEntries { get; set; }

        public int Count { get; set; } = 50;

    }
}
