using DatabaseFirst.Datos;
using DatabaseFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseFirst.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext contexto)
        {
             _context = contexto;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Consulta filtrando por fecha
            //DateTime fechaComparacion = new DateTime(2021, 11, 05);
            //List<Categoria> listaCategorias = _contexto.Categoria.Where(f => f.FechaCreacion >= fechaComparacion).OrderByDescending(f => f.FechaCreacion).ToList();
            //return View(listaCategorias);

            //Seleccionar columnas espefificas
            //var categorias = _contexto.Categoria.Where(n => n.Nombre == "Test 5").Select(n => n).ToList();
            //List<Categoria> listaCategorias = _contexto.Categoria.ToList();            

            ////Consultas sql convencioinales
            //var listaCategorias = _contexto.Categoria.FromSqlRaw("select * from categoria where nombre like 'categoría%' and Activo = 1").ToList();

            //Consultas sql convencioinales
            //var listaCategorias = _contexto.Categoria.FromSqlRaw("select * from categoria where nombre like 'categoría%' and Activo = 1").ToList();



            //Agrupar
            //var listaCategoriasAgrupadas = _context.Categoria
            //.GroupBy(c => new { c.Activo })
            //.Select(c => new { c.Key, Count = c.Count() }).ToList();

            //foreach(var item in listaCategoriasAgrupadas)
            //{
            //    Console.WriteLine("key "+item.Key+" Cantidad "+item.Count );
            //}


            //take y skip Paginar
            //List<Categoria> listaCategorias = _context.Categoria.Skip(3).Take(5).ToList();

            //Interpolacion de string (string interpolation)
            //var id = 4;
            //var categoria = _context.Categoria.FromSqlRaw($"select * from categoria where categoria_id = {id}").ToList();
            //List<Categoria> listaCategorias = _context.Categoria.ToList();

            List<Categoria> listaCategorias = _context.Categoria.ToList();

            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion2()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
                //_context.Categoria.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 5; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VistaCrearMultipleOpcionFormulario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string categoriasForm = Request.Form["Nombre"];
            var listaCategorias = from val in categoriasForm.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries) select (val);

            List<Categoria> categorias = new List<Categoria>();

            foreach (var categoria in listaCategorias)
            {
                categorias.Add(new Categoria
                {
                    Nombre = categoria
                });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var categoria = _context.Categoria.FirstOrDefault(c => c.Categoria_Id == id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.FechaCreacion=DateTime.Now;
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.Categoria_Id == id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple2()
        {
            IEnumerable<Categoria> categorias = _context.Categoria.OrderByDescending(c => c.Categoria_Id).Take(2);
            _context.Categoria.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple5()
        {
            IEnumerable<Categoria> categorias = _context.Categoria.OrderByDescending(c => c.Categoria_Id).Take(5);
            _context.Categoria.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
