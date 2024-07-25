using Api.Domain.Abstractions;
using Api.Domain.Grupos;
using MediatR;

namespace Api.Application.Grupos.Update;

public class UpdateGrupoCommandHandler : IRequestHandler<UpdateGrupoCommand, Result<int>>
{
    private readonly IRepository<Grupo> _grupoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGrupoCommandHandler(IRepository<Grupo> grupoRepository, IUnitOfWork unitOfWork)
    {
        _grupoRepository = grupoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(UpdateGrupoCommand request, CancellationToken cancellationToken)
    {
        var exist = await _grupoRepository.Exists(request.Id);

        if (!exist)
        {
            return Result<int>.Failure("Grupo.NotFound, No existe grupo con el Id solicitado");
        }

        var grupo = Grupo.CrearGrupo(
            request.Id,
            request.Nombre,
            request.Id_Lote
        );

        _grupoRepository.Update(grupo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(grupo.Id);
    }
}
