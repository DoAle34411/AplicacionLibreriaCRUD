using AplicacionLibreriaCRUD.Models;

namespace AplicacionLibreriaCRUD.Services
{
    public class APIServices : IAPIServices
    {
        private readonly HttpClient _httpClient;

        public APIServices(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration["API:Url"])
            };

        }
        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync("api/Producto/" + id);
        }

        public async Task<Producto> GetProduct(int id)
        {
            var producto = await _httpClient.GetFromJsonAsync<Producto>("api/Producto/" + id);
            return producto;
        }

        public async Task<List<Producto>> GetProducts()
        {
            var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
            return productos;
        }

        public async Task<Producto> POSTProducto(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return producto;
        }

        public async Task<Producto> PUTProducto(int IdProducto, Producto producto)
        {
            await _httpClient.PutAsJsonAsync("api/Producto/" + IdProducto, producto);
            return producto;
        }
    }
}