using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Lotes.GetById;

public record GetLoteByIdQuery(int Id) : IRequest<Result<LoteResponse>>;
