using EAuction.APIGateway.Data.Abstractions;
using EAuction.APIGateway.Models;
using EAuction.APIGateway.Settings;
using MongoDB.Driver;

namespace EAuction.APIGateway.Data
{
    public class UserContext : IUserContext
    {
        public UserContext(IUserDatabaseSettings settings)
        {       
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Users = database.GetCollection<User>(settings.CollectionName);        
           
        }
        public IMongoCollection<User> Users { get; set; }
    }
}