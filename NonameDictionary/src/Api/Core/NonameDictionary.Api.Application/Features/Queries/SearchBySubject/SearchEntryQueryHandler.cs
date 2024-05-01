using MediatR;
using Microsoft.EntityFrameworkCore;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Queries.SearchBySubject
{
    public class SearchEntryQueryHandler: IRequestHandler<SearchEntryQuery,List<SearchEntryViewModel>>
    {
        private readonly IEntryRepository entryRepository;

        public SearchEntryQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
        {
            // TODO validation yapılabilir request.searchtext length should should be checked
            var result = entryRepository.Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%")) // bu kod cümlenın başından itibaren aratır $"%{request.SearchText}% bu ise ortasından
                .Select(i => new SearchEntryViewModel()
                {
                    Id = i.Id,
                    Subject = i.Subject,
                });
            return await result.ToListAsync(cancellationToken);
        }
    }
}
