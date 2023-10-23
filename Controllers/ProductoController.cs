using AplicacionLibreriaCRUD.Models;
using AplicacionLibreriaCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AplicacionLibreriaCRUD.Controllers
{

    public class ProductoController : Controller
    {
        //GET: ProductoController
        private readonly IAPIServices _APIServices;

        public ProductoController(IAPIServices servicios)
        {
            _APIServices = servicios;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            var productos = await _APIServices.GetProducts();

            return View(productos);
        }

        // GET: ProductoController/Details/5
        /*public IActionResult Details(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Details(int id)
        {
            var producto = await _APIServices.GetProduct(id);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        /*public IActionResult Create(Producto producto)
        {
            int id = Utils.ListaProducto.Count() + 1;
            producto.IdProducto = id;
            Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }*/

        public async Task<IActionResult> Create(Producto producto)
        {
            await _APIServices.POSTProducto(producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        /*public IActionResult Edit(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto nuevo)
        {
            Producto antiguo = Utils.ListaProducto.Find(x => x.IdProducto == nuevo.IdProducto);
            if (antiguo != null)
            {
                antiguo.Nombre = nuevo.Nombre;
                antiguo.Descripcion = nuevo.Descripcion;
                antiguo.Cantidad = nuevo.Cantidad;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _APIServices.GetProduct(id);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            await _APIServices.PUTProducto(producto.IdProducto, producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        /*public IActionResult Delete(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                Utils.ListaProducto.Remove(producto);
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"El IdProducto fue: {id}");
            //await _httpClient.DeleteAsync($"api/Producto/{id}");
            await _APIServices.DeleteProducto(id);

            return RedirectToAction("Index");
        }

    }
}