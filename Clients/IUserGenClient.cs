using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersGenerator.Clients
{
    public interface IUserGenClient
    {
        Task<UserGenResponse> GetRandomUser(string nationality = "us", string password = "medium");
    }
}
