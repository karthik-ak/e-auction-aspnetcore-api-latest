using AutoMapper;
using EAuction.Order.Application.Commands.OrderCreate;
using EAuction.Order.Application.Responses;

namespace EAuction.Order.Application.Mapper
{
    public class BidMappingProfile : Profile
    {
        public BidMappingProfile()
        {
            CreateMap<Domain.Entities.Bid, BidCreateCommand>().ReverseMap();
            CreateMap<Domain.Entities.Bid, BidResponse>().ReverseMap();
        }
    }
}