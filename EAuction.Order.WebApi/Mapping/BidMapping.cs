using AutoMapper;
using EAuction.Order.Application.Commands.OrderCreate;
using EventBusRabbitMQ.Events;

namespace EAuction.Order.WebApi.Mapping
{
    public class BidMapping:Profile
    {
        public BidMapping()
        {
            CreateMap<BidCreateEvent, BidCreateCommand>().ReverseMap();
        }
    }
}