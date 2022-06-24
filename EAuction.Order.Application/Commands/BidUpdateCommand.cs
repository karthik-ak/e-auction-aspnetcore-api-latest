using System.Collections.Generic;
using EAuction.Order.Application.Responses;
using MediatR;

namespace EAuction.Order.Application.Commands
{
    public class BidUpdateCommand : IRequest<bool>
    {
        public string ProductId { get; set; }
        public string BuyerEmailId { get; set; }
        public decimal NewBidAmount { get; set; }

        public BidUpdateCommand(string productId, string buyerEmailId, decimal newBidAmount)
        {
            ProductId = productId;
            BuyerEmailId = buyerEmailId;
            NewBidAmount = newBidAmount;
        }
    }
}