using AppClientesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppClientesMVC.Controllers;

public class TelefonoController : Controller
{
    private readonly HttpClient _httpClient;

    public TelefonoController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClientes");
    }

    public async Task<IActionResult> Index(int clienteId)
    {
        var telefonos = await _httpClient.GetFromJsonAsync<List<Telefono>>($"api/telefonos/cliente/{clienteId}");
        ViewBag.ClienteId = clienteId;
        return View(telefonos);
    }

    public IActionResult Crear(int clienteId)
    {
        ViewBag.ClienteId = clienteId;
        return View(new Telefono { ClienteId = clienteId });
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Telefono telefono)
    {
        Console.WriteLine($"ClienteId recibido: {telefono.ClienteId}");
        Console.WriteLine($"Numero recibido: {telefono.Numero}");

        var response = await _httpClient.PostAsJsonAsync("api/telefonos", telefono);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Error del servidor: " + error);
        }

        return RedirectToAction("Index", new { clienteId = telefono.ClienteId });
    }

    public async Task<IActionResult> Eliminar(int id, int clienteId)
    {
        await _httpClient.DeleteAsync($"api/telefonos/{id}");
        return RedirectToAction("Index", new { clienteId });
    }
}