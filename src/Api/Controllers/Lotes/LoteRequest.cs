namespace Api.Controllers.Lotes;

public record LoteRequest(
    string Nombre,
    int Id_Finca,
    int Arboles,
    string Etapa
);