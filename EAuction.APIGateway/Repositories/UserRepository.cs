using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EAuction.APIGateway.Data.Abstractions;
using EAuction.APIGateway.Models;
using EAuction.APIGateway.Repositories.Abstractions;
using MongoDB.Driver;

namespace EAuction.APIGateway.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _context.Users.Find(p => true).ToListAsync();
            return result;
        }

        public async Task<User> GetUser(string emailId, string password)
        {
            if (string.IsNullOrEmpty(emailId) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Enter valid credentials...");
            }
            var result = await _context.Users.Find(p => p.Email.ToLower() == emailId.ToLower() && p.Password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task Create(User user)
        {
            if (_context.Users.Find(x => x.Email.ToLower() == user.Email.ToLower()).Any())
            {
                throw new Exception("Email already exist...");
            }
            await _context.Users.InsertOneAsync(user);
        }
    }
}