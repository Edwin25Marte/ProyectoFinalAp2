using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
    public class DetallePeliculas
    {
        [Key]

        public int DetallePeliculaId { get; set; }
        public int PeliculaId { get; set; }
        public string NombreActor { get; set; }
        public string Personaje { get; set; }

        public DetallePeliculas()
        {
            DetallePeliculaId = 0;
            PeliculaId = 0;
            NombreActor = string.Empty;
            Personaje = string.Empty;
        }

        public DetallePeliculas(int DetallePeliculaId, int PeliculaId, string NombreActor, string Personaje)
        {
            this.DetallePeliculaId = DetallePeliculaId;
            this.PeliculaId = PeliculaId;
            this.NombreActor = NombreActor;
            this.Personaje = Personaje;
        }
    }
}
