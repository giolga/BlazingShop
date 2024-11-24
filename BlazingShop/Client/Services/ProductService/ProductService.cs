using BlazingShop.Shared;
using System.Net.Http.Json;

namespace BlazingShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient http)
        {
            this._httpClient = http;
        }
        public async Task LoadProducts()
        {
            Products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
        }
    }
}
