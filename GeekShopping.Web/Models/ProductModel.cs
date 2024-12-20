namespace GeekShopping.Web.Models;

public class ProductModel
{
    public ProductModel()
    {
        Id = 0;
        Name = string.Empty;
        Price = 0;
    }

    public long Id { get; set; }

    public required string Name { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Category_name { get; set; }

    public required string ImagePath { get; set; }
}