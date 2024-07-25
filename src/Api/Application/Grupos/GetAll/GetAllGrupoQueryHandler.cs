using Api.Domain.Abstractions;
using Api.Domain.Grupos;
using MediatR;

namespace Api.Application.Grupos.GetAll;

public class GetAllGrupoQueryHandler : IRequestHandler<GetAllGrupoQuery, IEnumerable<GrupoResponse>>
{

    private readonly IRepository<Grupo> _grupoRepository;

    public GetAllGrupoQueryHandler(IRepository<Grupo> grupoRepository)
    {
        _grupoRepository = grupoRepository;
    }

    public async Task<IEnumerable<GrupoResponse>> Handle(GetAllGrupoQuery request, CancellationToken cancellationToken)
    {
        var grupos = await _grupoRepository.GetAllAsync();

        IEnumerable<GrupoResponse> grupoResponses = grupos.Select(grupo => new GrupoResponse(
            grupo.Id,
            grupo.Nombre!,
            grupo.Id_Lote!
        ));

        return grupoResponses;
    }
}
