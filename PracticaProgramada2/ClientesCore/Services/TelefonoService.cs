using ClientesCore.Entities;
using ClientesCore.Interfaces;

namespace ClientesCore.Services
{
    public class TelefonoService : ITelefonoService
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoService(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        public async Task<List<Telefono>> ObtenerPorClienteIdAsync(int clienteId)
        {
            return await _telefonoRepository.ObtenerPorClienteIdAsync(clienteId);
        }

        public async Task<Telefono> CrearAsync(Telefono telefono)
        {
            return await _telefonoRepository.CrearAsync(telefono);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _telefonoRepository.EliminarAsync(id);
        }
    }
}