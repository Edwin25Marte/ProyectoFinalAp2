using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Peliculas
    {
        [Key]

        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Inventario { get; set; }
        public decimal Precio { get; set; }
        public string Sipnosis { get; set; }

        public Peliculas()
        {
            PeliculaId = 0;
            Nombre = string.Empty;
            FechaSalida = DateTime.Now;
            Inventario = 0;
            Precio = 0;
            Sipnosis = string.Empty;
        }

        public Peliculas(int PeliculaId, string Nombre, DateTime FechaSalida, int Inventario, decimal Precio, string Sipnosis)
        {
            this.PeliculaId = PeliculaId;
            this.Nombre = Nombre;
            this.FechaSalida = FechaSalida;
            this.Inventario = Inventario;
            this.Precio = Precio;
            this.Sipnosis = Sipnosis;
        }
    }
}
