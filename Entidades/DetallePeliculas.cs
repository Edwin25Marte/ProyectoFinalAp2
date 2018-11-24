using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePeliculas
    {
        [Key]

        public int DPId { get; set; }
        public string NActor { get; set; }
        public string NGenero { get; set; }

        public DetallePeliculas()
        {
            DPId = 0;
            NActor = string.Empty;
            NGenero = string.Empty;
        }

        public DetallePeliculas(int DPId, string NActor, string NGenero)
        {
            this.DPId = DPId;
            this.NActor = NActor;
            this.NGenero = NGenero;
        }
    }
}
