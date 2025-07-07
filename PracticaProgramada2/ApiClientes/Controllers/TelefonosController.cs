using ClientesCore.Entities;
using ClientesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefonosController : ControllerBase
{
    private readonly ITelefonoService _telefonoService;

    public TelefonosController(ITelefonoService telefonoService)
    {
        _telefonoService = telefonoService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> GetByCliente(int clienteId)
    {
        return Ok(await _telefonoService.ObtenerPorClienteIdAsync(clienteId));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Telefono telefono)
    {
        if (!ModelState.IsValid)
        {
            var errores = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new { errores });
        }

        var creado = await _telefonoService.CrearAsync(telefono);
        return Ok(creado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _telefonoService.EliminarAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}