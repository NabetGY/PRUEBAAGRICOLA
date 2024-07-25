using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly FincaService _fincaService;

    public HomeController(FincaService fincaService)
    {
        _fincaService = fincaService;
    }

    public async Task<ActionResult<IEnumerable<Finca>>> Index()
    {
        var fincas = await _fincaService.GetAllAsync();
        return View(fincas);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add(Finca finca)
    {

        Console.WriteLine($"hola aqui {finca.Nombre}");

        var id = await _fincaService.Add(finca);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult<Finca>> Update(int id)
    {
        Finca? finca = await _fincaService.GetByIdAsync(id);

        return View(finca);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Finca finca)
    {
        var id = await _fincaService.UpdateAsync(finca);

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<ActionResult<Finca>> Delete(int id)
    {
        Finca? finca = await _fincaService.GetByIdAsync(id);

        return View(finca);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Finca finca)
    {
        var id = await _fincaService.DeleteAsync(finca);

        return RedirectToAction("Index");
    }

}
