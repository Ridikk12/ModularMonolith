using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.User.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsQueryResponse>
    {
        public GetUserDetailsQuery(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; }
    }
}
