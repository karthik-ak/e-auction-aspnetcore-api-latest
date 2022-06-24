using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EAuction.Order.Application.Commands.OrderCreate;
using EAuction.Order.Application.Responses;
using EAuction.Order.Domain.Repositories;
using MediatR;

namespace EAuction.Order.Application.Handlers
{
    public class BidCreateHandler : IRequestHandler<BidCreateCommand,BidResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public BidCreateHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public async Task<BidResponse> Handle(BidCreateCommand request, CancellationToken cancellationToken)
        {
            var bidEntity = _mapper.Map<Domain.Entities.Bid>(request);

            if (bidEntity==null)
            {
                throw new ApplicationException("Entity could not be mapped!");
            }

            var order = await _bidRepository.SendBid(bidEntity);

            var orderResponse = _mapper.Map<BidResponse>(order);

            return orderResponse;
        }
    }
}