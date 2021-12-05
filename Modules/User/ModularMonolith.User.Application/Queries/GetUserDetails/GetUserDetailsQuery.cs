using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ModularMonolith.User.Contracts;

namespace ModularMonolith.User.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDto>
    {
        public GetUserDetailsQuery(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; }
    }
}
