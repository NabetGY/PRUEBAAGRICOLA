using Api.Domain.Abstractions;
using Api.Domain.Grupos;
using MediatR;

namespace Api.Application.Grupos.Delete;

public class DeleteGrupoCommandHandler : IRequestHandler<DeleteGrupoCommand, Result<int>>
{
    private readonly IRepository<Grupo> _grupoRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteGrupoCommandHandler(IRepository<Grupo> grupoRepository, IUnitOfWork unitOfWork)
    {
        _grupoRepository = grupoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupo = await _grupoRepository.GetByIdAsync(request.Id);

        if (grupo is null)
        {
            return Result<int>.Failure("Grupo.NotFound, No existe grupo con el Id solicitado");
        }

        _grupoRepository.Delete(grupo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(grupo.Id);
    }
}
