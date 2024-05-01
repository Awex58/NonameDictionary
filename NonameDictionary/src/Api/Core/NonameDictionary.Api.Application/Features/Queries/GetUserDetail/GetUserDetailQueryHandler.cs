using AutoMapper;
using MediatR;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public GetUserDetailQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken) 
        {
            Domain.Models.User dbUser = null;
            if (request.UserId != Guid.Empty) 
                dbUser = await userRepository.GetByIdAsync(request.UserId);
            else if (!string.IsNullOrEmpty(request.UserName))
                dbUser = await userRepository.GetSingleAsync(i=>i.UserName == request.UserName);
            // todo if both are empty, throw new exception

            return mapper.Map<UserDetailViewModel>(dbUser);
        }
    }
}
