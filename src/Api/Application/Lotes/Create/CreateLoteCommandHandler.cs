using Api.Domain.Abstractions;
using Api.Domain.Lotes;
using MediatR;

namespace Api.Application.Lotes.Create;

public class CreateLoteCommandHandler : IRequestHandler<CreateLoteCommand, int>
{

    private readonly IRepository<Lote> _loteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLoteCommandHandler(IRepository<Lote> loteRepository, IUnitOfWork unitOfWork)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateLoteCommand request, CancellationToken cancellationToken)
    {
        var lote = Lote.CrearLote(null, request.Nombre, request.Id_Finca, request.Arboles, request.Etapa);

        _loteRepository.Add(lote);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return lote.Id;
    }
}
