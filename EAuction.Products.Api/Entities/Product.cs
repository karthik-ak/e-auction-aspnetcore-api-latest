using EAuction.Products.Api.CustomDataAnnotations;
using EAuction.Products.Api.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EAuction.Products.Api.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage ="Product Name cannot be empty")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="Product name should contain 5 to 30 characters")]
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public ProductCategory Category { get; set; }
        public decimal StartingPrice { get; set; }
        [CurrentDate(ErrorMessage = "Bid End Date cannot be in past date. Please enter valid future date.")]
        public DateTime BidEndDate { get; set; }

        [Required(ErrorMessage = "Seller First Name is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Product name should contain 5 to 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Seller Last Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Product name should contain 3 to 25 characters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Phone { get; set; }

        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Seller email is required")]
        [EmailAddress(ErrorMessage="Seller email is not valid")]
        public string Email { get; set; }     
    }
}