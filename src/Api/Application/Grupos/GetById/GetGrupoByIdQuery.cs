using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Grupos.GetById;

public record GetGrupoByIdQuery(int Id) : IRequest<Result<GrupoResponse>>;
