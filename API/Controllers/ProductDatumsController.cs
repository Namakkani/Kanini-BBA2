using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Data;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDatumsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductDatumsController(IProductServices productServices)
        {
            _productServices= productServices;
        }

        // GET: api/ProductDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDatum>>> GetProducts()
        {
            return await _productServices.GetProducts();
        }

        // GET: api/ProductDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDatum>> GetProductDatum(string id)
        {
            var prod = await _productServices.GetProductById(id);
            if (prod == null)
            {
                return NotFound("Product Id not matching");
            }
            return prod;
        }

        // PUT: api/ProductDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult>PutProductDatum(string id, ProductDatum productDatum)
        {
            var prod = await _productServices.UpdateProduct(id, productDatum);
            if (prod == null)
            {
                return NotFound("Product Id not matching");
            }
            return Ok(prod);
        }

        // POST: api/ProductDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDatum>> PostProductDatum(ProductDatum productDatum)
        {
            var prod = await _productServices.PostProduct(productDatum);
            return Ok(prod);
        }

        // DELETE: api/ProductDatums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDatum>> DeleteProductDatum(string id)
        {
            var prod = await _productServices.DeleteProduct(id);
            if (prod == null)
            {
                return NotFound("Prod id not matching");
            }
            return Ok(prod);    
        }

       
    }
}
