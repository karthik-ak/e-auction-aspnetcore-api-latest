using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EAuction.Products.Api.Entities;

namespace EAuction.Products.Api.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsUploadedBy(string mailId);
        Task<Product> GetProduct(string id);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}