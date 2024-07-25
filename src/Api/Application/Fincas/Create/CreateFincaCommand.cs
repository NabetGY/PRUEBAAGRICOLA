using MediatR;

namespace Api.Application.Fincas.Create;

public record CreateFincaCommand(
    string Nombre,
    string Ubicacion,
    decimal Hectareas,
    string Descripcion
): IRequest<int>;
