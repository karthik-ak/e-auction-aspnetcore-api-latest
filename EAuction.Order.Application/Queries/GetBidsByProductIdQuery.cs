using System.Collections.Generic;
using EAuction.Order.Application.Responses;
using MediatR;

namespace EAuction.Order.Application.Queries
{
    public class GetBidsByProductIdQuery : IRequest<IEnumerable<BidResponse>>
    {
        public GetBidsByProductIdQuery(string productId)
        {
            ProductId = productId;
        }

        public string ProductId { get; set; }

    }

    public class GetBidsByProductIdAndEmailIdQuery : IRequest<BidResponse>
    {
        public GetBidsByProductIdAndEmailIdQuery(string productId, string buyerEmailId)
        {
            ProductId = productId;
            BuyerEmailId = buyerEmailId;
        }

        public string ProductId { get; set; }
        public string BuyerEmailId { get; set; }
    }
}