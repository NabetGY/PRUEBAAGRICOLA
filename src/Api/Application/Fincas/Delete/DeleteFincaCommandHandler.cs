using Api.Domain.Abstractions;
using Api.Domain.Fincas;
using MediatR;

namespace Api.Application.Fincas.Delete;

public class DeleteFincaCommandHandler : IRequestHandler<DeleteFincaCommand, Result<int>>
{
    private readonly IRepository<Finca> _fincaRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteFincaCommandHandler(IRepository<Finca> fincaRepository, IUnitOfWork unitOfWork)
    {
        _fincaRepository = fincaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteFincaCommand request, CancellationToken cancellationToken)
    {
        var finca = await _fincaRepository.GetByIdAsync(request.Id);

        if (finca is null)
        {
            return Result<int>.Failure("Finca.NotFound, No existe finca con el Id solicitado");
        }

        _fincaRepository.Delete(finca);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(finca.Id);
    }
}
