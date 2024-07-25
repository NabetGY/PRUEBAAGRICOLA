using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Grupos.GetAll;

public record GetAllGrupoQuery() : IRequest<IEnumerable<GrupoResponse>>;
