using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Grupos.Delete;

public record DeleteGrupoCommand(int Id) : IRequest<Result<int>>;
