using AplicacionLibreriaCRUD.Models;

namespace AplicacionLibreriaCRUD.Services
{
    public interface IAPIServices
    {
        public Task<List<Producto>> GetProducts();
        public Task<Producto> GetProduct(int id);
        public Task<Producto> PUTProducto(int IdProducto, Producto producto);
        public Task<Producto> POSTProducto(Producto producto);
        public Task DeleteProducto(int id);
    }
}
