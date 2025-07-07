using System.ComponentModel.DataAnnotations;

namespace AppClientesMVC.Models;

public class Telefono
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El número de teléfono es obligatorio")]
    public string Numero { get; set; }
    public int ClienteId { get; set; }
}