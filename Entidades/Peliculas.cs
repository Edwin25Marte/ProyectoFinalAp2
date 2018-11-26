using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
    public class Peliculas
    {
        [Key]

        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Genero { get; set; }
        public string Personaje { get; set; }
        public string Sipnosis { get; set; }

        public virtual List<DetallePeliculas> DetallePels { get; set; }

        public Peliculas()
        {
            PeliculaId = 0;
            ActorId = 0;
            Nombre = string.Empty;
            FechaSalida = DateTime.Now;
            Cantidad = 0;
            Precio = 0;
            Genero = string.Empty;
            Personaje = string.Empty;
            Sipnosis = string.Empty;
            DetallePels = new List<DetallePeliculas>();
        }

        public Peliculas(int PeliculaId, string Nombre, int ActorId, DateTime FechaSalida, int Cantidad, decimal Precio, string Genero, string Personaje, string Sipnosis, List<DetallePeliculas> DetallePels)
        {
            this.PeliculaId = PeliculaId;
            this.ActorId = ActorId;
            this.Nombre = Nombre;
            this.FechaSalida = FechaSalida;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Genero = Genero;
            this.Personaje = Personaje;
            this.Sipnosis = Sipnosis;
            this.DetallePels = DetallePels;
        }
    }
}
