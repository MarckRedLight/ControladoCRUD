using System;
using System.Collections.Generic;

#nullable disable

namespace WS_Factura.Models
{
    public partial class Detalle
    {
        public long IdDetalle { get; set; }
        public long IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal MontoLinea { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
