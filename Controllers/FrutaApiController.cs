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

    public async Task<IActionResult> Index()
    {
        var frutas = await _frutaService.GetFrutasAsync(); // List<FrutaApi>
        return View(frutas);
    }

    [HttpPost]
    public async Task<IActionResult> Find(string nombre)
    {
        var frutas = await _frutaService.SearchFrutasAsync(nombre); // List<FrutaApi>
        return View("Index", frutas);
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
