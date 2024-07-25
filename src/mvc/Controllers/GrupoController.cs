using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers;

public class GrupoController : Controller
{
    private readonly GrupoService _grupoService;
    private readonly LoteService _loteService;

    public GrupoController(GrupoService grupoService, LoteService loteService)
    {
        _grupoService = grupoService;
        _loteService = loteService;
    }

    public async Task<ActionResult<IEnumerable<Grupo>>> Index()
    {
        var lotes = await _loteService.GetAllAsync();
        var grupos = await _grupoService.GetAllAsync();

        var modelo = grupos.Select(grupo =>
        {
            var lote = lotes.FirstOrDefault(l => l.Id == grupo.Id_Lote);
            return new Grupo(
                grupo.Id,
                grupo.Id_Lote,
                grupo.Nombre,
                lote.Nombre
            );
        }).ToList();
        return View(modelo);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var lotes = await ObtenerLotes();

        var modelo = new GrupoAddViewModel
        {
            Lotes = lotes
        };

        return View(modelo);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Grupo lote)
    {

        var id = await _grupoService.Add(lote);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult<Grupo>> Update(int id)
    {
        Grupo? grupo = await _grupoService.GetByIdAsync(id);

        var lotes = await ObtenerLotes();

        var modelo = new GrupoAddViewModel
        {
            Id = grupo.Id,
            Id_Lote = grupo.Id_Lote,
            Nombre = grupo.Nombre,
            Lotes = lotes
        };

        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Grupo lote)
    {
        var id = await _grupoService.UpdateAsync(lote);

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<ActionResult<Grupo>> Delete(int id)
    {
        Grupo? lote = await _grupoService.GetByIdAsync(id);

        return View(lote);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Grupo lote)
    {
        var id = await _grupoService.DeleteAsync(lote);

        return RedirectToAction("Index");
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerLotes()
    {
        var lotes = await _loteService.GetAllAsync();
        return lotes.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }

}
