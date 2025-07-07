using ClientesCore.Entities;
using ClientesCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientesCore.DataAccess
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly AppDbContext _context;

        public TelefonoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Telefono>> ObtenerPorClienteIdAsync(int clienteId)
        {
            return await _context.Telefonos
                .Where(t => t.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Telefono> CrearAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null) return false;

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}