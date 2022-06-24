using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EAuction.Order.Application.Queries;
using EAuction.Order.Application.Responses;
using EAuction.Order.Domain.Repositories;
using MediatR;

namespace EAuction.Order.Application.Handlers
{
    public class GetBidsByProductIdHandler : IRequestHandler<GetBidsByProductIdQuery, IEnumerable<BidResponse>>,
                                        IRequestHandler<GetBidsByProductIdAndEmailIdQuery, BidResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;
        public GetBidsByProductIdHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BidResponse>> Handle(GetBidsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var bidList = await _bidRepository.GetBids(request.ProductId);

            var response = _mapper.Map<IEnumerable<BidResponse>>(bidList);

            return response;
        }

        public async Task<BidResponse> Handle(GetBidsByProductIdAndEmailIdQuery request, CancellationToken cancellationToken)
        {
            var bidList = await _bidRepository.GetBid(request.ProductId, request.BuyerEmailId);

            var response = _mapper.Map<BidResponse>(bidList);

            return response;
        }
    }
}