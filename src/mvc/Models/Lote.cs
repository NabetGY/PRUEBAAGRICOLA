using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc.Models;

public record Lote(
    int Id,
    int Id_Finca,
    string Nombre,
    int Arboles,
    string Etapa,
    string? FincaNombre
);
