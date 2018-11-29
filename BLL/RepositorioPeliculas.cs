using Entidades;
using System;
using System.Data.Entity;
using System.Linq;

namespace BLL
{
    public class RepositorioPeliculas : RepositorioBase<Peliculas>
    {
        public RepositorioPeliculas() : base()
        { }

        public override bool Modificar(Peliculas Fact)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                _contexto.Entry(Fact).State = EntityState.Modified;
                foreach (DetallePeliculas detalle in Fact.DetallePels)
                {
                    var pelAnterior = _contexto.Facturas.Include(x => x.DetalleFactura.Select(z => z.Pelicula))
                      .Where(s => s.FacturaId == Fact.PeliculaId)
                      .AsNoTracking()
                      .FirstOrDefault();

                    if (detalle.DetallePeliculaId > 0)
                        _contexto.Entry(detalle).State = EntityState.Modified;
                    else
                        _contexto.Entry(detalle).State = EntityState.Added;
                }
                _contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            { throw; }
            return paso;
        }

        public bool DeleteP(int Id)
        {
            bool paso = false;
            try
            {
                DetallePeliculas Entidad = _contexto.DetalleP.Find(Id);
                _contexto.DetalleP.Remove(Entidad);

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            return paso;
        }
    }
}
