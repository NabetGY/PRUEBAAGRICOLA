namespace Api.Controllers.Fincas;

public record FincaCreateRequest(
    string Nombre,
    string Ubicacion,
    decimal Hectareas,
    string Descripcion
);