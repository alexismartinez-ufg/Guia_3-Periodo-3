using Ejercicio_1.BAL.Interfaces;
using Ejercicio_1.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_1.Controllers
{
    public class ContactoController(IContactoService service) : Controller
    {
        // Obtener todos los contactos
        public IActionResult Index()
        {
            try
            {
                List<Contacto> contactos = service.GetAllContactos();
                return View(contactos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al obtener contactos: " + ex.Message;
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        // Agregar un nuevo contacto
        [HttpPost]
        public IActionResult Create(Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Datos del contacto no son válidos.";
                return View("Error");
            }

            try
            {
                service.AddContacto(contacto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al agregar contacto: " + ex.Message;
                return View("Error");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var contacto = service.GetContactoById(id);
                if (contacto == null)
                {
                    ViewBag.Error = "El contacto no fue encontrado.";
                    return View("Error");
                }

                return View(contacto); // Pasar el modelo a la vista
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al obtener detalles del contacto: " + ex.Message;
                return View("Error");
            }
        }

        // Actualizar un contacto existente
        [HttpPost]
        public IActionResult Edit(int id, Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Datos del contacto no son válidos.";
                return View("Error");
            }

            try
            {
                Contacto existingContact = service.GetContactoById(id);
                if (existingContact == null)
                {
                    ViewBag.Error = "El contacto no fue encontrado.";
                    return View("Error");
                }

                service.UpdateContacto(contacto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar contacto: " + ex.Message;
                return View("Error");
            }
        }

        // Obtener un contacto por ID
        public IActionResult Detail(int id)
        {
            try
            {
                Contacto contacto = service.GetContactoById(id);
                if (contacto == null)
                {
                    ViewBag.Error = "Contacto no encontrado.";
                    return View("Error");
                }
                return View("Details", contacto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al obtener detalles del contacto: " + ex.Message;
                return View("Error");
            }
        }

        // Eliminar un contacto
        public IActionResult Delete(int id)
        {
            try
            {
                Contacto contacto = service.GetContactoById(id);
                if (contacto == null)
                {
                    ViewBag.Error = "El contacto no fue encontrado.";
                    return View("Error");
                }

                service.DeleteContacto(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar contacto: " + ex.Message;
                return View("Error");
            }
        }
    }
}
