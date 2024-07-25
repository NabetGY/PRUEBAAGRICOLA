namespace Api.Application.Grupos;

public sealed record GrupoResponse(
    int Id,
    string Nombre,
    int Id_Lote
);
