using AplicacionLibreriaCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AplicacionLibreriaCRUD.Controllers
{

    public class ProductoController : Controller
    {
        //GET: ProductoController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaProducto);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto producto = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            int id = Util.Utils.ListaProducto.Count()+1;
            producto.IdProducto = id;
            Util.Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int IdProducto)
        {
            Producto producto = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            Console.WriteLine(JsonSerializer.Serialize(producto));
            int id = producto.IdProducto;
            Producto productoViejo = Util.Utils.ListaProducto.Find(x => x.IdProducto == id);
            if (productoViejo != null) {
                int indice = Util.Utils.ListaProducto.FindIndex(x => x.IdProducto == id);
                Util.Utils.ListaProducto[indice].Cantidad = producto.Cantidad;
                Util.Utils.ListaProducto[indice].Nombre = producto.Nombre;
                Util.Utils.ListaProducto[indice].Descripcion = producto.Descripcion;
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            Producto producto = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                Util.Utils.ListaProducto.Remove(producto);
            }
            else if (producto == null)
            {
                                
            }
            return RedirectToAction("Index");
        }
    
    }
}