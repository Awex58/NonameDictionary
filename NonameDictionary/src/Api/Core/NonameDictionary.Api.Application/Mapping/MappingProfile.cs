using AutoMapper;
using NonameDictionary.Api.Domain.Models;
using NonameDictionary.Common.Models.Queries;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, LoginUserViewModel>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<Entry, CreateEntryCommand>().ReverseMap();

            CreateMap<EntryComment, CreateEntryCommentCommand>().ReverseMap();

        }
    }
}
