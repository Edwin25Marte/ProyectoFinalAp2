using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Serializable]
    public class DetalleFacturas
    {
        [Key]
        
        public int FactDetalleId { get; set; }
        public int FacturaId { get; set; }
        public int PeliculaId { get; set; }
        public string NombrePelicula { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Peliculas Pelicula { get; set; }

        public DetalleFacturas()
        {
            FactDetalleId = 0;
            FacturaId = 0;
            PeliculaId = 0;
            NombrePelicula = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }

        public DetalleFacturas(int FactDetalleId, int FacturaId, int PeliculaId, string NombrePelicula, int Cantidad, decimal Precio)
        {
            this.FactDetalleId = FactDetalleId;
            this.FacturaId = FacturaId;
            this.PeliculaId = PeliculaId;
            this.NombrePelicula = NombrePelicula;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
