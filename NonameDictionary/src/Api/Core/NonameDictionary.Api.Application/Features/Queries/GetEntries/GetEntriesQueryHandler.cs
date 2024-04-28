using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Models.Queries;

namespace NonameDictionary.Api.Application.Features.Queries.GetEntries
{
    public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModel>>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper mapper;

        public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetEntriesViewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();
            if (request.TodaysEntries)
            {
                query = query
                    .Where(i => i.CreateDate >= DateTime.Now.Date)
                    .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);
            }
            query = query.Include(i => i.EntryComments)
                .OrderBy(i => Guid.NewGuid())
                .Take(request.Count);


            return await query.ProjectTo<GetEntriesViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
