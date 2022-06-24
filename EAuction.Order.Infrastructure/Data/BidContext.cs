
using EAuction.Order.Domain.Entities;
using EAuction.Order.Infrastructure.Settings;
using MongoDB.Driver;

namespace EAuction.Order.Infrastructure.Data
{
    public class BidContext : IBidContext
    {
        public BidContext(IBidDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Bids = database.GetCollection<Bid>(settings.CollectionName);
        }
        public IMongoCollection<Bid> Bids { get; set; }        
    }
}