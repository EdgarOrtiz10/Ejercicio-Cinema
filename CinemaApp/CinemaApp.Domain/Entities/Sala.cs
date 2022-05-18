using System;
using System.Collections.Generic;

namespace CinemaApp.Domain.Entities
{
    public partial class Sala
    {
        public Sala()
        {
            Funcions = new HashSet<Funcion>();
        }

        public int IdSala { get; set; }
        public string Nomenclatura { get; set; } = null!;
        public int Capacidad { get; set; }
        public bool EsDinamix { get; set; }
        public bool Activa { get; set; }

        public virtual ICollection<Funcion> Funcions { get; set; }
    }
}
