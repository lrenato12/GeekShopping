using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;

    public const string BasePath = "https://localhost:5157/api/v1/Product";

    #region [ CTOR ]
    public ProductService(HttpClient client)
    {
        _client = client;
    }
    #endregion

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _client.GetAsync(BasePath);

        if (response == null || !response.IsSuccessStatusCode)
            return Enumerable.Empty<ProductModel>();

        var content = await response.ReadContentAsync<List<ProductModel>>();

        return content ?? Enumerable.Empty<ProductModel>();
    }
    
    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{BasePath}/{id}");

        var content = await response.ReadContentAsync<ProductModel>();

        return content ?? new ProductModel { ImagePath = "", Name = "" };
    }

    public async Task<ProductModel> CreateProduct(ProductModel requestModel)
    {
        var response = await _client.PostAsJson(BasePath, requestModel);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong when calling API");

        var content = await response.ReadContentAsync<ProductModel>();

        return content ?? new ProductModel { ImagePath = "", Name = "" };
    }

    public async Task<ProductModel> UpdateProduct(ProductModel requestModel)
    {
        var response = await _client.PutAsJson(BasePath, requestModel);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong when calling API");

        var content = await response.ReadContentAsync<ProductModel>();

        return content ?? new ProductModel { ImagePath = "", Name = "" };
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _client.DeleteAsync($"{BasePath}/{id}");

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong when calling API");

        return await response.ReadContentAsync<bool>();
    }
}