using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Grupos.Update;

public record UpdateGrupoCommand(
    int Id,
    string Nombre,
    int Id_Lote
) : IRequest<Result<int>>;
