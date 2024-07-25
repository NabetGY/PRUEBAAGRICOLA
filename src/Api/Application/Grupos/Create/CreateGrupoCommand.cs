using MediatR;

namespace Api.Application.Grupos.Create;

public record CreateGrupoCommand(
    string Nombre,
    int Id_Lote
): IRequest<int>;
