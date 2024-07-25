using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Fincas.Delete;

public record DeleteFincaCommand(int Id) : IRequest<Result<int>>;
