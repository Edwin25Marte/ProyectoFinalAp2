using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entidades;

namespace BLL
{
    public class RepositorioFactura : RepositorioBase<Facturas>
    {
        public RepositorioFactura() : base()
        { }

        public override bool Guardar(Facturas entity)
        {
            return base.Guardar(entity);
        }

        public override bool Modificar(Facturas Fact)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                _contexto.Entry(Fact).State = EntityState.Modified;
                foreach (DetalleFacturas detalle in Fact.DetalleFactura)
                {
                    var pelAnterior = _contexto.Facturas.Include(x => x.DetalleFactura.Select(z => z.Pelicula))
                      .Where(s => s.FacturaId == Fact.FacturaId)
                      .AsNoTracking()
                      .FirstOrDefault();

                    var pel = _contexto.Peliculas.Find(detalle.PeliculaId);

                    if (detalle.FactDetalleId > 0)
                    {
                        foreach (var it in pelAnterior.DetalleFactura)
                        {
                            var Pel = _contexto.Peliculas.Find(it.PeliculaId);
                            Pel.Cantidad -= it.Cantidad;
                        }

                        pel.Cantidad -= detalle.Cantidad;

                        _contexto.Entry(pel).State = EntityState.Modified;
                        _contexto.Entry(detalle).State = EntityState.Modified;
                    }
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

        public bool Delete(int Id)
        {
            bool paso = false;
            try
            {
                DetalleFacturas Entidad = _contexto.Detalle.Find(Id);
                _contexto.Detalle.Remove(Entidad);

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            return paso;
        }
    }
}
