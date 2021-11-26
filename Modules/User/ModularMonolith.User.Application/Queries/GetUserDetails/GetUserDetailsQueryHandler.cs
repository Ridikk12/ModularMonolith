using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.User.Infrastructure.Entities;

namespace ModularMonolith.User.Application.Queries.GetUserDetails
{
    class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetUserDetailsQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GetUserDetailsQueryResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException(request.UserId, nameof(AppUser));

            return new GetUserDetailsQueryResponse(user.UserName, user.Name, user.Surname);
        }
    }
}
