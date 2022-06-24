using AutoMapper;
using EAuction.Order.Application.Commands;
using EAuction.Order.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EAuction.Order.Application.Handlers
{
    public class UpdateBidAmountHandler : IRequestHandler<BidUpdateCommand, bool>
    {
        private readonly IBidRepository _bidRepository;       
        public UpdateBidAmountHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;           
        }

        public async Task<bool> Handle(BidUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _bidRepository.UpdateBidAmount(request.ProductId, request.BuyerEmailId, request.NewBidAmount);

            return result;
        }
    }
}