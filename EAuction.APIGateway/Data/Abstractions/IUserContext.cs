using EAuction.APIGateway.Models;
using MongoDB.Driver;

namespace EAuction.APIGateway.Data.Abstractions
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; set; }
    }
}