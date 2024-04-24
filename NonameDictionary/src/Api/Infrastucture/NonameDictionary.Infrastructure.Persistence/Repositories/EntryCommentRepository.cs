using Microsoft.EntityFrameworkCore;
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
    internal class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(NonameDictionaryContext dbContext) : base(dbContext)
        {
        }
    }
}
