using Api.Application.Lotes.Create;
using Api.Application.Lotes.Delete;
using Api.Application.Lotes.GetAll;
using Api.Application.Lotes.GetById;
using Api.Application.Lotes.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Lotes;

[ApiController]
[Route("api/lotes")]
public class LoteController : ControllerBase
{
    private readonly ISender _sender;

    public LoteController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CrearLote(LoteRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateLoteCommand(
            request.Id_Finca,
            request.Nombre,
            request.Arboles,
            request.Etapa
        );

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpGet("searchById")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetLoteByIdQuery(id);

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
        var query = new GetAllLoteQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,[FromBody] LoteRequest request)
    {
        var command = new UpdateLoteCommand(
            id,
            request.Nombre,
            request.Id_Finca,
            request.Arboles,
            request.Etapa
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
        var command = new DeleteLoteCommand(id);

        var result = await _sender.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
