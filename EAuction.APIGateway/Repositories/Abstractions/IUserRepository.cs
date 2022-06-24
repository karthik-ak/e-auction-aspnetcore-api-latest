using EAuction.APIGateway.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EAuction.APIGateway.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string emailId, string password);
        Task Create(User user);        
    }
}