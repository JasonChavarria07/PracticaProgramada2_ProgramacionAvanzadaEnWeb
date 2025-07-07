using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesCore.Entities
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
