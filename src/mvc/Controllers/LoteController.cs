using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers;

public class LoteController : Controller
{
    private readonly LoteService _loteService;
    private readonly FincaService _fincaService;

    public LoteController(LoteService loteService, FincaService fincaService)
    {
        _loteService = loteService;
        _fincaService = fincaService;
    }

    public async Task<ActionResult<IEnumerable<Lote>>> Index()
    {
        var fincas = await _fincaService.GetAllAsync();
        var lotes = await _loteService.GetAllAsync();

        var modelo = lotes.Select(lote =>
        {
            var finca = fincas.FirstOrDefault(f => f.Id == lote.Id_Finca);
            return new Lote(
                lote.Id,
                lote.Id_Finca,
                lote.Nombre,
                lote.Arboles,
                lote.Etapa,
                finca.Nombre
            );
        }).ToList();
        return View(modelo);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var fincas = await ObtenerFincas();

        var modelo = new LoteAddViewModel
        {
            Fincas = fincas
        };

        return View(modelo);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Lote lote)
    {

        var id = await _loteService.Add(lote);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult<Lote>> Update(int id)
    {
        Lote? lote = await _loteService.GetByIdAsync(id);

        var fincas = await ObtenerFincas();

        var modelo = new LoteAddViewModel
        {
            Id = lote.Id,
            Id_Finca = lote.Id_Finca,
            Arboles = lote.Arboles,
            Etapa = lote.Etapa,
            Nombre = lote.Nombre,
            Fincas = fincas
        };

        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Lote lote)
    {
        var id = await _loteService.UpdateAsync(lote);

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<ActionResult<Lote>> Delete(int id)
    {
        Lote? lote = await _loteService.GetByIdAsync(id);

        return View(lote);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Lote lote)
    {
        var id = await _loteService.DeleteAsync(lote);

        return RedirectToAction("Index");
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerFincas()
    {
        var fincas = await _fincaService.GetAllAsync();
        return fincas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }

}
