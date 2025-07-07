using ClientesCore.Entities;

namespace ClientesCore.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<List<Telefono>> ObtenerPorClienteIdAsync(int clienteId);
        Task<Telefono> CrearAsync(Telefono telefono);
        Task<bool> EliminarAsync(int id);
    }
}