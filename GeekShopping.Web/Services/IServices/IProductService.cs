using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProducts();
    Task<ProductModel> FindProductById(long id);
    Task<ProductModel> CreateProduct(ProductModel requestModel);
    Task<ProductModel> UpdateProduct(ProductModel requestModel);
    Task<bool> DeleteProductById(long id);
}