namespace mvc.Models;

public record Finca(
    int Id,
    string Nombre,
    string Ubicacion,
    decimal Hectareas,
    string Descripcion    
);
