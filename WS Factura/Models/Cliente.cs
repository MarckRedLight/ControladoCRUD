using System;
using System.Collections.Generic;

#nullable disable

namespace WS_Factura.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public long Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
