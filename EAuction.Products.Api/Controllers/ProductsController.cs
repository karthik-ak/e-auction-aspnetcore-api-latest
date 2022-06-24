using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EAuction.Products.Api.Entities;
using EAuction.Products.Api.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using EAuction.Products.Api.Enums;

namespace EAuction.Products.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Variables

        private IProductRepository _productRepository;
        private ILogger<ProductsController> _logger;
        

        #endregion
        #region Constructor
        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        #endregion
        #region CRUD_Actions
               
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return Ok(products);
        }
        [HttpGet("GetProductsUploadedBy/{emailId}")]        
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsUploadedBy(string emailId)
        {
            var products = await _productRepository.GetProductsUploadedBy(emailId);

            return Ok(products);
        }

        [HttpGet("GetProduct/{id}")]        
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"Product with id : {id}, has not been found in database.");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("CreateProduct")]     
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productRepository.Create(product);
            return Ok(product);
        }
      

        [HttpPut("UpdateProduct")]        
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result =await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{productId}")]        
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string productId)
        {
            var result = await _productRepository.Delete(productId);
            return Ok(result);
        }

        #endregion
    }

}
