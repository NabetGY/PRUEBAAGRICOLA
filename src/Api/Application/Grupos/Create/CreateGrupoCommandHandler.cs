using Api.Domain.Abstractions;
using Api.Domain.Grupos;
using MediatR;

namespace Api.Application.Grupos.Create;

public class CreateGrupoCommandHandler : IRequestHandler<CreateGrupoCommand, int>
{

    private readonly IRepository<Grupo> _grupoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGrupoCommandHandler(IRepository<Grupo> grupoRepository, IUnitOfWork unitOfWork)
    {
        _grupoRepository = grupoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupo = Grupo.CrearGrupo(null, request.Nombre, request.Id_Lote);

        _grupoRepository.Add(grupo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return grupo.Id;
    }
}
