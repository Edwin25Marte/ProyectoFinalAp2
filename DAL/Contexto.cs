using System;
using System.Collections.Generic;
using System.Data.Entity;
using Entidades;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Actores> Actores { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DetalleFacturas> Detalle { get; set; }
        public DbSet<DetallePeliculas> DetalleP { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
