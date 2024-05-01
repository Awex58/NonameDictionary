using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Common.Models.Queries
{
    public class SearchEntryQuery:IRequest<List<SearchEntryViewModel>> //controllerda yollucagımız ıcın queryı commonda olusturduk
    {
        public string SearchText { get; set; }

        public SearchEntryQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
