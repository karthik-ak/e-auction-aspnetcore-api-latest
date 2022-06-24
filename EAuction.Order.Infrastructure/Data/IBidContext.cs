using EAuction.Order.Domain.Entities;
using MongoDB.Driver;

namespace EAuction.Order.Infrastructure.Data
{
    public interface IBidContext
    {   
        IMongoCollection<Bid> Bids { get; set; }       
    }
}