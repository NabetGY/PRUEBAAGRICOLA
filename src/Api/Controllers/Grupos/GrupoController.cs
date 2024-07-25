using Api.Application.Grupos.Create;
using Api.Application.Grupos.Delete;
using Api.Application.Grupos.GetAll;
using Api.Application.Grupos.GetById;
using Api.Application.Grupos.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Grupos;

[ApiController]
[Route("api/grupos")]
public class GrupoController : ControllerBase
{
    private readonly ISender _sender;

    public GrupoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CrearGrupo(GrupoRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateGrupoCommand(
            request.Nombre,
            request.Id_Lote
        );

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpGet("searchById")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetGrupoByIdQuery(id);

        var result = await _sender.Send(query);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllGrupoQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,[FromBody] GrupoRequest request)
    {
        var command = new UpdateGrupoCommand(
            id,
            request.Nombre,
            request.Id_Lote
        );

        var result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteGrupoCommand(id);

        var result = await _sender.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
