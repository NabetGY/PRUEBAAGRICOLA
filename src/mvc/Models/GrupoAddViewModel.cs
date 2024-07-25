using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc.Models;

public class GrupoAddViewModel
{
    public int Id { get; set; }
    public int Id_Lote { get; set; }
    public string? Nombre { get; set; }
    public IEnumerable<SelectListItem>? Lotes  { get; set; }
}
