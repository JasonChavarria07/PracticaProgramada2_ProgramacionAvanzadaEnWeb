using ClientesCore.Entities;
using ClientesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> Get()
    {
        return await _clienteService.ObtenerTodosAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _clienteService.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();
        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
    {
        var creado = await _clienteService.CrearAsync(cliente);
        return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        var actualizado = await _clienteService.ActualizarAsync(cliente);
        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _clienteService.EliminarAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}