using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BASE_PATH = "api/v1/Product";

    public ProductService()
    {
        
    }

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _client.GetAsync(BASE_PATH);

        return await response.ReadContentAsync<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAsync<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel requestModel)
    {
        var response = await _client.PostAsJson(BASE_PATH, requestModel);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAsync<ProductModel>();

        throw new Exception("Something went wrong when calling API");
    }

    public async Task<ProductModel> UpdateProduct(ProductModel requestModel)
    {
        var response = await _client.PutAsJson(BASE_PATH, requestModel);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAsync<ProductModel>();

        throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _client.DeleteAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAsync<bool>();
    }
}