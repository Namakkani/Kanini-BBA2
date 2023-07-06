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
            _productServices = productServices;
        }

        // GET: api/ProductDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDatum>>> GetProducts()
        {
            try
            {
                return await _productServices.GetProducts();
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred while fetching products: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching products.");
            }
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDatum>> GetProductDatum(string id)
        {
            try
            {
                var prod = await _productServices.GetProductById(id);
                if (prod == null)
                {
                    return NotFound("Product Id not matching");
                }
                return prod;
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine($"An error occurred while fetching the product: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the product.");
            }
        }

        // PUT: api/ProductDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDatum(string id, ProductDatum productDatum)
        {
            try
            {
                var prod = await _productServices.UpdateProduct(id, productDatum);
                if (prod == null)
                {
                    return NotFound("Product Id not matching");
                }
                return Ok(prod);
            }
            catch (Exception ex)
            {
                // Handle or log the exception here
                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }

        // POST: api/ProductDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDatum>> PostProductDatum(ProductDatum productDatum)
        {
            try
            {
                var prod = await _productServices.PostProduct(productDatum);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while creating the product: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the product.");
            }
        }

        // DELETE: api/ProductDatums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDatum>> DeleteProductDatum(string id)
        {
            try
            {
                var prod = await _productServices.DeleteProduct(id);
                if (prod == null)
                {
                    return NotFound("Product Id not matching");
                }
                return Ok(prod);
            }
            catch (Exception ex)
            {
                // Handle or log the exception here
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the product.");
            }
        }
    }
}
