using Api.Domain.Abstractions;
using Api.Domain.Lotes;
using MediatR;

namespace Api.Application.Lotes.GetById;

public sealed class GetLoteByIdQueryHandler : IRequestHandler<GetLoteByIdQuery, Result<LoteResponse>>
{
    private readonly IRepository<Lote> _loteRepository;

    public GetLoteByIdQueryHandler(IRepository<Lote> loteRepository)
    {
        _loteRepository = loteRepository;
    }

    public async Task<Result<LoteResponse>> Handle(GetLoteByIdQuery request, CancellationToken cancellationToken)
    {
        var lote = await  _loteRepository.GetByIdAsync(request.Id);

        if (lote is null)
        {
            return Result<LoteResponse>.Failure("Error.NotFound");
        }

        var response = new LoteResponse(lote.Id, lote.Nombre!, lote.Id_Finca!, lote.Arboles, lote.Etapa!);

        return Result<LoteResponse>.Success(response);
    }
}
