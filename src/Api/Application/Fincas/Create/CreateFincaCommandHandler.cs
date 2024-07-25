using Api.Domain.Abstractions;
using Api.Domain.Fincas;
using MediatR;

namespace Api.Application.Fincas.Create;

public class CreateFincaCommandHandler : IRequestHandler<CreateFincaCommand, int>
{

    private readonly IRepository<Finca> _fincaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFincaCommandHandler(IRepository<Finca> fincaRepository, IUnitOfWork unitOfWork)
    {
        _fincaRepository = fincaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateFincaCommand request, CancellationToken cancellationToken)
    {
        var finca = Finca.CrearFinca(null, request.Nombre, request.Ubicacion, request.Hectareas, request.Descripcion);

        _fincaRepository.Add(finca);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return finca.Id;
    }
}
