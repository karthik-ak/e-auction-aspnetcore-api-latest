using System;

namespace EAuction.Order.Application.Responses
{
    public class BidResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string ProductId { get; set; }
        public decimal BidAmount { get; set; }
        public string BidStatus { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}