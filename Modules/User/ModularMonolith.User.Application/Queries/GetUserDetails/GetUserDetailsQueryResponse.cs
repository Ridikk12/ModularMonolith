using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.User.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQueryResponse
    {
        public GetUserDetailsQueryResponse(string userName, string name, string surname)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
        }
        public string UserName { get; }
        public string Name { get; }
        public string Surname { get; }
    }
}
