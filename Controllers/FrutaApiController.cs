using Microsoft.AspNetCore.Mvc;
using Tarea1.Services;
using Tarea1.Models;

namespace Tarea1.Controllers
{
    public class FrutaApiController : Controller
    {
        private readonly FrutaService _frutaService;

        public FrutaApiController(FrutaService frutaService)
        {
            _frutaService = frutaService;
        }

        // Index con ordenamiento
        public async Task<IActionResult> Index(string sortBy = "", string order = "asc")
        {
            var frutas = await _frutaService.GetFrutasAsync();

            // Ordenamiento según parámetros
            frutas = sortBy.ToLower() switch
            {
                "carbohidratos" => order == "desc"
                    ? frutas.OrderByDescending(f => f.Nutriciones?.Carbohidratos).ToList()
                    : frutas.OrderBy(f => f.Nutriciones?.Carbohidratos).ToList(),

                "proteina" => order == "desc"
                    ? frutas.OrderByDescending(f => f.Nutriciones?.Proteina).ToList()
                    : frutas.OrderBy(f => f.Nutriciones?.Proteina).ToList(),

                "grasa" => order == "desc"
                    ? frutas.OrderByDescending(f => f.Nutriciones?.Grasa).ToList()
                    : frutas.OrderBy(f => f.Nutriciones?.Grasa).ToList(),

                "calorias" => order == "desc"
                    ? frutas.OrderByDescending(f => f.Nutriciones?.Calorias).ToList()
                    : frutas.OrderBy(f => f.Nutriciones?.Calorias).ToList(),

                "azucar" => order == "desc"
                    ? frutas.OrderByDescending(f => f.Nutriciones?.Azucar).ToList()
                    : frutas.OrderBy(f => f.Nutriciones?.Azucar).ToList(),

                _ => frutas
            };

            return View(frutas);
        }

        [HttpPost]
        public async Task<IActionResult> Find(string nombre)
        {
            var frutas = await _frutaService.GetFrutasAsync();
            var resultado = frutas
                .Where(f => f.Nombre != null && f.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();

            return View("Index", resultado);
        }

        public async Task<IActionResult> Details(int id)
        {
            var frutas = await _frutaService.GetFrutasAsync();
            var fruta = frutas.FirstOrDefault(f => f.Id == id);
            if (fruta == null)
                return NotFound();

            return View(fruta);
        }
    }
}
