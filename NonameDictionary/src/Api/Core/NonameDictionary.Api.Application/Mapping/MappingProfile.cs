using AutoMapper;
using NonameDictionary.Api.Domain.Models;
using NonameDictionary.Common.Models.Queries;
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
        }
    }
}
