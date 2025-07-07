﻿using ClientesCore.Entities;
using ClientesCore.Interfaces;

namespace ClientesCore.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _clienteRepository.ObtenerTodosAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _clienteRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Cliente> CrearAsync(Cliente cliente)
        {
            return await _clienteRepository.CrearAsync(cliente);
        }

        public async Task<Cliente> ActualizarAsync(Cliente cliente)
        {
            return await _clienteRepository.ActualizarAsync(cliente);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _clienteRepository.EliminarAsync(id);
        }
    }
}