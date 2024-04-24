﻿using Microsoft.EntityFrameworkCore;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Api.Domain.Models;
using NonameDictionary.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Infrastructure.Persistence.Repositories
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(NonameDictionaryContext dbContext) : base(dbContext)
        {
        }
    }
}
