using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc.Models;

public class LoteAddViewModel
{
    public int Id { get; set; }
    public int Id_Finca { get; set; }
    public string? Nombre { get; set; }
    public int Arboles { get; set; }
    public string? Etapa { get; set; }
    public IEnumerable<SelectListItem>? Fincas  { get; set; }
}
