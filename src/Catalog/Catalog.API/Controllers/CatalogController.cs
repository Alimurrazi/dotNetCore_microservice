using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            this.repository = repository;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await repository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(string id)
        {
            var product = await repository.GetProduct(id);

            if(product == null)
            {
                _logger.LogError($"property with id: {id}, not found");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var products = await repository.GetProductsByCategory(category);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct([FromBody]Product product)
        {
            await repository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct([FromBody]Product product)
        {
            return Ok(await repository.Update(product));
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProductById(string id)
        {
            return Ok(await repository.Delete(id));
        }
    }
}