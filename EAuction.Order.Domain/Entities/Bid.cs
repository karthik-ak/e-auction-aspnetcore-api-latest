using System;
using System.ComponentModel.DataAnnotations;
using EAuction.Order.Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAuction.Order.Domain.Entities
{
    public class Bid : Entity
    {
        [Required(ErrorMessage = "Buyer First Name is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Buyer name should contain 5 to 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Buyer Last Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Buyer name should contain 3 to 25 characters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "Seller email is required")]
        [EmailAddress(ErrorMessage = "Seller email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Product Id cannot be empty")]
        public string ProductId { get; set; }
        public decimal BidAmount { get; set; }
        public string BidStatus { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}