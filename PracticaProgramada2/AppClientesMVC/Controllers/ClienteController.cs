using AppClientesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppClientesMVC.Controllers;

public class ClienteController : Controller
{
    private readonly HttpClient _httpClient;

    public ClienteController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClientes");
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes");
        return View(clientes);
    }

    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Cliente cliente)
    {
        var response = await _httpClient.PostAsJsonAsync("api/clientes", cliente);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        return View(cliente);
    }

    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
        if (cliente == null) return NotFound();

        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Cliente cliente)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/clientes/{cliente.Id}", cliente);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        return View(cliente);
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/clientes/{id}");
        return RedirectToAction("Index");
    }
}