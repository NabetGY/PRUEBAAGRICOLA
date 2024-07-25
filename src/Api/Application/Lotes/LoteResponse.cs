namespace Api.Application.Lotes;

public sealed record LoteResponse(
    int Id,
    string Nombre,
    int Id_Finca,
    int Arboles,
    string Etapa    
);
