using Api.Domain.Abstractions;
using Api.Domain.Lotes;
using MediatR;

namespace Api.Application.Lotes.Update;

public class UpdateLoteCommandHandler : IRequestHandler<UpdateLoteCommand, Result<int>>
{
    private readonly IRepository<Lote> _loteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLoteCommandHandler(IRepository<Lote> loteRepository, IUnitOfWork unitOfWork)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(UpdateLoteCommand request, CancellationToken cancellationToken)
    {
        var exist = await _loteRepository.Exists(request.Id);

        if (!exist)
        {
            return Result<int>.Failure("Lote.NotFound, No existe lote con el Id solicitado");
        }

        var lote = Lote.CrearLote(
            request.Id,
            request.Nombre,
            request.Id_Finca,
            request.Arboles,
            request.Etapa
        );

        _loteRepository.Update(lote);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(lote.Id);
    }
}
