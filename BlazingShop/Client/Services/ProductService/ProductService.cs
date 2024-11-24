using BlazingShop.Shared;
using System.Net.Http.Json;

namespace BlazingShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private readonly HttpClient _httpClient;

        public event Action OnChange;

        public ProductService(HttpClient http)
        {
            this._httpClient = http;
        }

        public async Task LoadProducts(string categoryUrl = null)
        {
            if (categoryUrl == null)
            {
                Products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
            }
            else
            {
                Products = await _httpClient.GetFromJsonAsync<List<Product>>($"api/Product/Category/{categoryUrl}");
            }
            OnChange.Invoke();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }
    }
}
