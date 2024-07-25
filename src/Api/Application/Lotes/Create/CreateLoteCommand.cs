using MediatR;

namespace Api.Application.Lotes.Create;

public record CreateLoteCommand(
    int Id_Finca,
    string Nombre,
    int Arboles,
    string Etapa
): IRequest<int>;
