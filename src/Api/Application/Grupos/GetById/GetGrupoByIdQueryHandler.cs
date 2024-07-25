using Api.Domain.Abstractions;
using Api.Domain.Grupos;
using MediatR;

namespace Api.Application.Grupos.GetById;

public sealed class GetGrupoByIdQueryHandler : IRequestHandler<GetGrupoByIdQuery, Result<GrupoResponse>>
{
    private readonly IRepository<Grupo> _grupoRepository;

    public GetGrupoByIdQueryHandler(IRepository<Grupo> grupoRepository)
    {
        _grupoRepository = grupoRepository;
    }

    public async Task<Result<GrupoResponse>> Handle(GetGrupoByIdQuery request, CancellationToken cancellationToken)
    {
        var grupo = await  _grupoRepository.GetByIdAsync(request.Id);

        if (grupo is null)
        {
            return Result<GrupoResponse>.Failure("Error.NotFound");
        }

        var response = new GrupoResponse(grupo.Id, grupo.Nombre!, grupo.Id_Lote!);

        return Result<GrupoResponse>.Success(response);
    }
}
