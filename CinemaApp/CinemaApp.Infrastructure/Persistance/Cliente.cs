using System;
using System.Collections.Generic;

namespace CinemaApp.Infrastructure.Persistance
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public string IdCliente { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
