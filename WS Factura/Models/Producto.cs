using System;
using System.Collections.Generic;

#nullable disable

namespace WS_Factura.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
