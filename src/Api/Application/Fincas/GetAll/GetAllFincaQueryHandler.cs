using Api.Domain.Abstractions;
using Api.Domain.Fincas;
using MediatR;

namespace Api.Application.Fincas.GetAll;

public class GetAllFincaQueryHandler : IRequestHandler<GetAllFincaQuery, IEnumerable<FincaResponse>>
{

    private readonly IRepository<Finca> _fincaRepository;

    public GetAllFincaQueryHandler(IRepository<Finca> fincaRepository)
    {
        _fincaRepository = fincaRepository;
    }

    public async Task<IEnumerable<FincaResponse>> Handle(GetAllFincaQuery request, CancellationToken cancellationToken)
    {
        var fincas = await _fincaRepository.GetAllAsync();

        IEnumerable<FincaResponse> fincaResponses = fincas.Select(finca => new FincaResponse(
            finca.Id,
            finca.Nombre!,
            finca.Ubicacion!,
            finca.Hectareas,
            finca.Descripcion!
        ));

        return fincaResponses;
    }
}
