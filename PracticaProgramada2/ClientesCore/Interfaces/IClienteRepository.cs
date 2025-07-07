using ClientesCore.Entities;

namespace ClientesCore.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
    Task<Cliente> CrearAsync(Cliente cliente);
    Task<Cliente> ActualizarAsync(Cliente cliente);
    Task<bool> EliminarAsync(int id);
}