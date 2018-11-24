using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuario
    {
        [Key]

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            FechaNacimiento = DateTime.Now;
            Direccion = string.Empty;
            Telefono = string.Empty;
        }

        public Usuario(int UsuarioId, string NombreUsuario, string Password, DateTime FechaNacimiento, string Direccion, string Telefono)
        {
            this.UsuarioId = UsuarioId;
            this.NombreUsuario = NombreUsuario;
            this.Password = Password;
            this.FechaNacimiento = FechaNacimiento;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
    }
}
