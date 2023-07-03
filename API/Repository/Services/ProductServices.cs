using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Data;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;

namespace RoleBasedAuthorization.Repository.Services
{
    public class ProductServices:IProductServices
    {
        public RoleBasedAuthorizationDbContext _dbContext;

        public ProductServices(RoleBasedAuthorizationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<ProductDatum>?> GetProducts()
        {
            var prod = await _dbContext.Products.ToListAsync();
            return prod;
        }

        public async Task<ProductDatum>?GetProductById(string id)
        {
            var prod = await _dbContext.Products.FindAsync(id);
            if (prod == null)
            {
                return null;
            }
            return prod;
        }

        public async Task<List<ProductDatum>?>UpdateProduct(string id, ProductDatum productDatum)
        {
            var prod = await _dbContext.Products.FindAsync(id);
            if (prod == null) { return null; }
            prod.ProductName = productDatum.ProductName;
            prod.QuantityAvailable = productDatum.QuantityAvailable;
            prod.Cost= productDatum.Cost;

            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products.ToListAsync() ;
        }

        public async Task<List<ProductDatum>>PostProduct(ProductDatum productDatum)
        {
            _dbContext.Products.Add(productDatum);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<ProductDatum>>DeleteProduct(string id)
        {
            var prod = _dbContext.Products.Find(id);
            if (prod is null)
            {
                return null;
            }
            _dbContext.Remove(prod);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products.ToListAsync();

        }

    }
}
