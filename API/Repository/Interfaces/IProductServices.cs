using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Repository.Interfaces
{
    public interface IProductServices
    {
        public Task<List<ProductDatum>?> GetProducts();
        public Task<ProductDatum>? GetProductById(string id);
        public Task<List<ProductDatum>?> UpdateProduct(string id, ProductDatum productDatum);
        public Task<List<ProductDatum>> PostProduct(ProductDatum productDatum);
        public Task<List<ProductDatum>> DeleteProduct(string id);
    }
}
