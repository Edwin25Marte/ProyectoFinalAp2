using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Actores
    {
        [Key]

        public int ActorId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDebut { get; set; }

        public Actores()
        {
            ActorId = 0;
            Nombre = string.Empty;
            FechaDebut = DateTime.Now;
        }

        public Actores(int ActorId, string Nombre, DateTime FechaDebut)
        {
            this.ActorId = ActorId;
            this.Nombre = Nombre;
            this.FechaDebut = FechaDebut;
        }
    }
}
