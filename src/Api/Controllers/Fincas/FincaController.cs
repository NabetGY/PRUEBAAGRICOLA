using Api.Application.Fincas.Create;
using Api.Application.Fincas.Delete;
using Api.Application.Fincas.GetAll;
using Api.Application.Fincas.GetById;
using Api.Application.Fincas.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Fincas;

[ApiController]
[Route("api/fincas")]
public class FincaController : ControllerBase
{
    private readonly ISender _sender;

    public FincaController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CrearFinca(FincaCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateFincaCommand(
            request.Nombre,
            request.Ubicacion,
            request.Hectareas,
            request.Descripcion
        );

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpGet("searchById")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetFincaByIdQuery(id);

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
        var query = new GetAllFincaQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,[FromBody] FincaCreateRequest request)
    {
        var command = new UpdateFincaCommand(
            id,
            request.Nombre,
            request.Ubicacion,
            request.Hectareas,
            request.Descripcion
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
        var command = new DeleteFincaCommand(id);

        var result = await _sender.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
