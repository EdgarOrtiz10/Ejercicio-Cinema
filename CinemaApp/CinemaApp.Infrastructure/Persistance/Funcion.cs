using System;
using System.Collections.Generic;

namespace CinemaApp.Infrastructure.Persistance
{
    public partial class Funcion
    {
        public Funcion()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdFuncion { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CapacidadMaxima { get; set; }
        public int AsientosDisponibles { get; set; }
        public decimal PrecioBoleta { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;
        public virtual Sala IdSalaNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
