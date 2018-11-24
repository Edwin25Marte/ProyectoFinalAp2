using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Clientes
    {
        [Key]

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Facturas { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Facturas = 0;
            FechaNacimiento = DateTime.Now;
            Telefono = string.Empty;
            Email = string.Empty;
        }

        public Clientes(int ClienteId, string Nombre, string Direccion, int Facturas, DateTime FechaNacimiento, string Telefono, string Email)
        {
            this.ClienteId = ClienteId;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Facturas = Facturas;
            this.FechaNacimiento = FechaNacimiento;
            this.Telefono = Telefono;
            this.Email = Email;
        }
    }
}
