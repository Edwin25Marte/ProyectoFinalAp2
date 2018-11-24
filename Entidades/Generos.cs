using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Generos
    {
        [Key]

        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Generos()
        {
            GeneroId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
        public Generos(int GeneroId, string Nombre, string Descripcion)
        {
            this.GeneroId = GeneroId;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }
    }
}
