using System;
using System.Collections.Generic;

namespace CinemaApp.Domain.Entities
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public Guid IdentificadorBoleta { get; set; }
        public bool Redimida { get; set; }
        public DateTime? FechaUso { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
    }
}
