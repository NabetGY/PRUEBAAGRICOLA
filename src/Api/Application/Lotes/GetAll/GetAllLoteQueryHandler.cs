using Api.Domain.Abstractions;
using Api.Domain.Lotes;
using MediatR;

namespace Api.Application.Lotes.GetAll;

public class GetAllLoteQueryHandler : IRequestHandler<GetAllLoteQuery, IEnumerable<LoteResponse>>
{

    private readonly IRepository<Lote> _loteRepository;

    public GetAllLoteQueryHandler(IRepository<Lote> loteRepository)
    {
        _loteRepository = loteRepository;
    }

    public async Task<IEnumerable<LoteResponse>> Handle(GetAllLoteQuery request, CancellationToken cancellationToken)
    {
        var lotes = await _loteRepository.GetAllAsync();

        IEnumerable<LoteResponse> loteResponses = lotes.Select(lote => new LoteResponse(
            lote.Id,
            lote.Nombre!,
            lote.Id_Finca!,
            lote.Arboles,
            lote.Etapa!
        ));

        return loteResponses;
    }
}
