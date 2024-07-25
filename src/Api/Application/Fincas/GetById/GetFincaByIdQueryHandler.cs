using Api.Domain.Abstractions;
using Api.Domain.Fincas;
using MediatR;

namespace Api.Application.Fincas.GetById;

public sealed class GetFincaByIdQueryHandler : IRequestHandler<GetFincaByIdQuery, Result<FincaResponse>>
{
    private readonly IRepository<Finca> _fincaRepository;

    public GetFincaByIdQueryHandler(IRepository<Finca> fincaRepository)
    {
        _fincaRepository = fincaRepository;
    }

    public async Task<Result<FincaResponse>> Handle(GetFincaByIdQuery request, CancellationToken cancellationToken)
    {
        var finca = await  _fincaRepository.GetByIdAsync(request.Id);

        if (finca is null)
        {
            return Result<FincaResponse>.Failure("Error.NotFound");
        }

        var response = new FincaResponse(finca.Id, finca.Nombre!, finca.Ubicacion!, finca.Hectareas, finca.Descripcion!);

        return Result<FincaResponse>.Success(response);
    }
}
