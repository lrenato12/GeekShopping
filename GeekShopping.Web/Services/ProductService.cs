using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    public async Task<ProductModel> CreateProduct(ProductModel requestModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProductById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductModel> UpdateProduct(ProductModel requestModel)
    {
        throw new NotImplementedException();
    }
}