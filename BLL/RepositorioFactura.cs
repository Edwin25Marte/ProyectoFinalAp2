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

        /*public override bool Modificar(Facturas Fact)
        {
            bool flag = false;
            _contexto = new DAL.Contexto();
            try
            {
                _contexto.Entry(Fact).State = EntityState.Modified;
                foreach (DetalleFacturas detalle in Fact.DetalleFactura)
                    _contexto.Entry(detalle).State = EntityState.Modified;

                _contexto.SaveChanges();
                flag = true;
            }
            catch (Exception)
            { throw; }
            return flag;
        }*/

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
                            it.Pelicula.Cantidad -= it.Cantidad;

                        pel.Cantidad += detalle.Cantidad;

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
    }
}
