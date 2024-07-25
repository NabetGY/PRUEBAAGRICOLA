using Api.Domain.Abstractions;
using MediatR;

namespace Api.Application.Lotes.Delete;

public record DeleteLoteCommand(int Id) : IRequest<Result<int>>;
