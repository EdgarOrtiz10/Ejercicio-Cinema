using System;
using System.Collections.Generic;

namespace CinemaApp.Domain.Entities
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Funcions = new HashSet<Funcion>();
        }

        public int IdPelicula { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sinopsis { get; set; } = null!;
        public int Duracion { get; set; }
        public string Director { get; set; } = null!;
        public string ActorPrincipal { get; set; } = null!;
        public bool Disponible { get; set; }

        public virtual ICollection<Funcion> Funcions { get; set; }
    }
}
