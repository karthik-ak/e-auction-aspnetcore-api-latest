
using System.Collections.Generic;
using System.Threading.Tasks;
using EAuction.Order.Domain.Entities;
using EAuction.Order.Domain.Repositories.Base;
namespace EAuction.Order.Domain.Repositories
{
    public interface IBidRepository
    {
        Task<IEnumerable<Entities.Bid>> GetBidsByProductId(string userName);
        Task<Bid> SendBid(Bid bid);
        Task<IEnumerable<Bid>> GetBids(string productId);
        Task<Bid> GetBid(string productId, string buyerEmailId);
        Task<bool> UpdateBidAmount(string productId, string buyerEmailId, decimal newBidAmount);
        Task<bool> AcceptBid(Bid bid);
        Task<bool> RejectBid(Bid bid);
    }
}