namespace Api.Application.Fincas;

public sealed record FincaResponse(
    int Id,
    string Nombre,
    string Ubicacion,
    decimal Hectareas,
    string Descripcion    
);
