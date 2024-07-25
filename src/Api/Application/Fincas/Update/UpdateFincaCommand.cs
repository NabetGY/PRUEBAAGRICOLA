using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Fincas.Update;

public record UpdateFincaCommand(
    int Id,
    string Nombre,
    string Ubicacion,
    decimal Hectareas,
    string Descripcion
) : IRequest<Result<int>>;
