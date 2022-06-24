using System.Collections.Generic;
using EAuction.Products.Api.Entities;
using EAuction.Products.Api.Enums;
using MongoDB.Driver;

namespace EAuction.Products.Api.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                 productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Category = ProductCategory.Painting,
                    ShortDescription = "Painting",
                    BidEndDate = new System.DateTime(2022, 12, 31),
                    ProductName = "IPhone",
                    StartingPrice = 1200M,
                    LongDescription = "iphone",
                    FirstName = "YUVAN100",
                    LastName = "SHANKAR",
                    Address = "TEST ADDRESS",
                    City = "CHENNAI",
                    State = "TN",
                    Pin = "78393829",
                    Phone = 908787898,
                    Email = "test@mail.com"

                },
                new Product
                {
                    Category = ProductCategory.Painting,
                    ShortDescription = "Phone",
                    BidEndDate = new System.DateTime(2022, 11, 28),
                    ProductName = "Xiaomi",
                    StartingPrice = 1200M,
                    LongDescription = "iphone",
                    FirstName = "YUVAN103",
                    LastName = "SHANKAR",
                    Address = "TEST ADDRESS",
                    City = "CHENNAI",
                    State = "TN",
                    Pin = "78393829",
                    Phone = 908787898,
                    Email = "test@mail.com"
                },
                new Product
                {
                    Category = ProductCategory.Ornament,
                    ShortDescription = "Phone",
                    BidEndDate = new System.DateTime(2022, 10, 15),
                    ProductName = "Samsung",
                    StartingPrice = 1200M,
                    LongDescription = "iphone",
                    FirstName = "YUVAN101",
                    LastName = "SHANKAR",
                    Address = "TEST ADDRESS",
                    City = "CHENNAI",
                    State = "TN",
                    Pin = "78393829",
                    Phone = 908787898,
                    Email = "test@mail.com"
                },
                new Product
                {
                    Category = ProductCategory.Sculptord,
                    ShortDescription = "Phone",
                    BidEndDate = new System.DateTime(2022, 09, 16),
                    ProductName = "Huawei",
                    StartingPrice = 1200M,
                    LongDescription = "iphone",
                    FirstName = "YUVAN102",
                    LastName = "SHANKAR",
                    Address = "TEST ADDRESS",
                    City = "CHENNAI",
                    State = "TN",
                    Pin = "78393829",
                    Phone = 908787898,
                    Email = "test@mail.com"
                },
            };
        }
    }
}