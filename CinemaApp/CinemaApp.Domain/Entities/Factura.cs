using System;
using System.Collections.Generic;

namespace CinemaApp.Domain.Entities
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string? IdCliente { get; set; }
        public int IdFuncion { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorNeto { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Funcion IdFuncionNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
