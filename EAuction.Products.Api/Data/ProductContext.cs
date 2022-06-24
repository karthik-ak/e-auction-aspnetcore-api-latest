using EAuction.Products.Api.Data.Abstractions;
using EAuction.Products.Api.Entities;
using EAuction.Products.Api.Settings;
using MongoDB.Driver;

namespace EAuction.Products.Api.Data
{
    public class ProductContext:IProductContext
    {
        public ProductContext(IProductDatabaseSettings settings)
        {       
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            Bids = database.GetCollection<Bid>("Bids");
            // ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; set; }

        public IMongoCollection<Bid> Bids { get; set; }
    }
}