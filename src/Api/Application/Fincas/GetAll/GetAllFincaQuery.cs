using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Fincas.GetAll;

public record GetAllFincaQuery() : IRequest<IEnumerable<FincaResponse>>;
