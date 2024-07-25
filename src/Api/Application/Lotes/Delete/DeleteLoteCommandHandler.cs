using Api.Domain.Abstractions;
using Api.Domain.Lotes;
using MediatR;

namespace Api.Application.Lotes.Delete;

public class DeleteLoteCommandHandler : IRequestHandler<DeleteLoteCommand, Result<int>>
{
    private readonly IRepository<Lote> _loteRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteLoteCommandHandler(IRepository<Lote> loteRepository, IUnitOfWork unitOfWork)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteLoteCommand request, CancellationToken cancellationToken)
    {
        var lote = await _loteRepository.GetByIdAsync(request.Id);

        if (lote is null)
        {
            return Result<int>.Failure("Lote.NotFound, No existe lote con el Id solicitado");
        }

        _loteRepository.Delete(lote);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(lote.Id);
    }
}
