using Microsoft.AspNetCore.Mvc;
using Prueba_YamaAndrade.Data;
using Prueba_YamaAndrade.Models;
using Microsoft.EntityFrameworkCore;
using Prueba_YamaAndrade.Services;

namespace Prueba_YamaAndrade.Controllers
{
    public class PersonaController : Controller
    {
        private readonly AppDBContext _appDbContext;
        private readonly PersonaService _personaService;

        public PersonaController(AppDBContext appDbContext, PersonaService personaService)
        {
            _appDbContext = appDbContext;
            _personaService = personaService;
        }

        public IActionResult Listar(string mensaje)
        {
            if (!string.IsNullOrEmpty(mensaje))
            {
                ViewBag.Mensaje = mensaje;
            }

            var personas = _appDbContext.Personas.ToList();
            return View(personas);
        }


        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Persona persona)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _appDbContext.Personas.AddAsync(persona);
                    await _appDbContext.SaveChangesAsync();

                    return Json(new { success = true, redirectUrl = Url.Action("Listar", "Persona", new { mensaje = "Persona creada exitosamente" }) });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Ocurrió un error al crear la persona: " + ex.Message });
                }
            }
            return Json(new { success = false, message = "Datos no válidos." });
        }




        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Persona persona = await _appDbContext.Personas.FirstAsync(p => p.IdPersona == id);
            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Personas.Update(persona);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Listar");
            }

            return View(persona);
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                // Lógica para eliminar la persona por id
                var persona = _appDbContext.Personas.Find(id);
                if (persona != null)
                {
                    _appDbContext.Personas.Remove(persona);
                    _appDbContext.SaveChanges();
                    return Json(new { success = true, message = "Persona eliminada correctamente." });
                }
                else
                {
                    return Json(new { success = false, message = "Persona no encontrada." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar la persona: " + ex.Message });
            }
        }


        [HttpPost]
        public JsonResult CrearTabla()
        {
            try
            {
                // Llama al servicio o lógica para crear la tabla
                _personaService.CrearTablaPersona($"PersonasCopia_{DateTime.Now:yyyyMMddHHmmss}");
                 return Json(new { success = true, message = "La copia de la tabla se realizó exitosamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al crear la copia de la tabla: {ex.Message}" });
            }
        }

    }
}
