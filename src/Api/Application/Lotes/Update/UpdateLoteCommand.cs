using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Lotes.Update;

public record UpdateLoteCommand(
    int Id,
    string Nombre,
    int Id_Finca,
    int Arboles,
    string Etapa
) : IRequest<Result<int>>;
