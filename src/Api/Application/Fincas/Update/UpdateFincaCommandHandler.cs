using Api.Domain.Abstractions;
using Api.Domain.Fincas;
using MediatR;

namespace Api.Application.Fincas.Update;

public class UpdateFincaCommandHandler : IRequestHandler<UpdateFincaCommand, Result<int>>
{
    private readonly IRepository<Finca> _fincaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFincaCommandHandler(IRepository<Finca> fincaRepository, IUnitOfWork unitOfWork)
    {
        _fincaRepository = fincaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(UpdateFincaCommand request, CancellationToken cancellationToken)
    {
        var exist = await _fincaRepository.Exists(request.Id);

        if (!exist)
        {
            return Result<int>.Failure("Finca.NotFound, No existe finca con el Id solicitado");
        }

        var finca = Finca.CrearFinca(
            request.Id,
            request.Nombre,
            request.Ubicacion,
            request.Hectareas,
            request.Descripcion
        );

        _fincaRepository.Update(finca);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(finca.Id);
    }
}
