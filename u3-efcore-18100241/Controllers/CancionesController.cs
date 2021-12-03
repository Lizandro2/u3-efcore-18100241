using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using u3_efcore_18100241.Models;

namespace u3_efcore_18100241.Controllers
{
    public class CancionesController : Controller
    {
        private readonly MusicBDContext db;

        public CancionesController(MusicBDContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var listadoPersonajes = db.Canciones.Include(i => i.IdArtistaNavigation);
            return View(listadoPersonajes.ToList());
        }

        public IActionResult AgregarArtistas()
        {
            Artista artista= new Artista { Nombre = "Aleman" };
            //insertar en la bd
            db.Add(artista);
            db.SaveChanges();

            Artista artista2 = new Artista { Nombre = "Gera MX" };
            //insertar en la bd
            db.Add(artista2);
            db.SaveChanges();

            Artista artista3 = new Artista { Nombre = "Cartel de Santa" };
            //insertar en la bd
            db.Add(artista3);
            db.SaveChanges();

            Artista artista4 = new Artista { Nombre = "Dharius" };
            //insertar en la bd
            db.Add(artista4);
            db.SaveChanges();

            Artista artista5 = new Artista { Nombre = "Santa Fe Klan" };
            //insertar en la bd
            db.Add(artista5);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult NuevaCancion()
        {
            ViewBag.Artista = new SelectList(db.Artistas, "IdArtista", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult NuevaCancion(Cancione cancion)
        {
            if (ModelState.IsValid)
            {
                //insertar en la bd
                db.Add(cancion);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(cancion);

        }

        public IActionResult EditarCancion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cancion = db.Canciones.Find(id);

            if (cancion == null)
            {
                return NotFound();
            }

            ViewBag.Artista = new SelectList(db.Artistas, "IdArtista", "Nombre");
            return View(cancion);

        }
        [HttpPost]
        public IActionResult EditarCancion(Cancione cancion)
        {

            if (ModelState.IsValid)
            {
                //Actualiza en la bd
                db.Update(cancion);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public IActionResult ElminarCancion(int id)
        {
            var cancion = db.Canciones.Find(id);

            if (cancion == null)
            {
                return NotFound();
            }

            db.Remove(cancion);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
