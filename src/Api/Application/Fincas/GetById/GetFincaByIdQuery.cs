using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Fincas.GetById;

public record GetFincaByIdQuery(int Id) : IRequest<Result<FincaResponse>>;
