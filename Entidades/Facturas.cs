﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
    public class Facturas
    {
        [Key]

        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal Monto { get; set; }
        public string Observaciones { get; set; }
        public virtual List<DetalleFacturas> DetalleFactura { get; set; }

        public Facturas()
        {
            FacturaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            FechaDevolucion = DateTime.Now;
            Monto = 0;
            Observaciones = string.Empty;
            DetalleFactura = new List<DetalleFacturas>();
        }

        public Facturas(int FacturaId, int ClienteId, DateTime Fecha, DateTime FechaDevolucion, decimal Monto, string Observaciones, List<DetalleFacturas> DetalleFactura)
        {
            this.FacturaId = FacturaId;
            this.ClienteId = ClienteId;
            this.Fecha = Fecha;
            this.FechaDevolucion = FechaDevolucion;
            this.Monto = Monto;
            this.Observaciones = Observaciones;
            this.DetalleFactura = DetalleFactura;
        }
    }
}
