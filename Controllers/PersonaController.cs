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

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Persona> listar = await _appDbContext.Personas.ToListAsync();
            return View(listar);
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
               await _appDbContext.Personas.AddAsync(persona);
               await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Listar");
            }

            return View(persona);
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

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Persona persona = await _appDbContext.Personas.FirstAsync(p => p.IdPersona == id);
            if (ModelState.IsValid)
            {
                _appDbContext.Personas.Remove(persona);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Listar");
            }

            return View(persona);
        }


        public IActionResult CrearTabla()
        {
            // Generar un nombre único para la tabla (por ejemplo, basado en la fecha y hora)
            string nuevoNombreTabla = "PersonaCopia_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Llamar al servicio para ejecutar el procedimiento almacenado
            _personaService.CrearTablaPersona(nuevoNombreTabla);

            return RedirectToAction("Listar"); // Redirigir a la lista de personas
        }
    }
}
