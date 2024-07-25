namespace Api.Controllers.Grupos;

public record GrupoRequest(
    string Nombre,
    int Id_Lote
);