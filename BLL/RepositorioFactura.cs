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

        public override bool Modificar(Facturas Fact)
        {
            bool flag = false;
            _contexto = new DAL.Contexto();
            try {
                var FDDB = _contexto.DFacturas.Where(x => x.FacturaId == Fact.FacturaId).ToList();
                //Elimina las cuotas de base de datos
                foreach (var item in FDDB) {
                    _contexto.DFacturas.Remove(item);
                }
                //Agrega la nueva lista
                foreach (var item in Fact.DetalleFactura) {
                    _contexto.Entry(item).State = EntityState.Added;
                }

                _contexto.Entry(Fact).State = EntityState.Modified;
                _contexto.SaveChanges();
                flag = true;
            }
            catch (Exception)
            { throw; }
            return flag;
        }
    }
}
