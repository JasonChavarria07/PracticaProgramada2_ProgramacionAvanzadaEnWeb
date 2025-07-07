using ClientesCore.Entities;
using ClientesCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientesCore.DataAccess;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObtenerTodosAsync()
    {
        return await _context.Clientes.Include(c => c.Telefonos).ToListAsync();
    }

    public async Task<Cliente?> ObtenerPorIdAsync(int id)
    {
        return await _context.Clientes.Include(c => c.Telefonos).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente> CrearAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> ActualizarAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}