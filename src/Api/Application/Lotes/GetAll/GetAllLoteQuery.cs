using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Lotes.GetAll;

public record GetAllLoteQuery() : IRequest<IEnumerable<LoteResponse>>;
