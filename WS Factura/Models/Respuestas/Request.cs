using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_Factura.Models.Respuestas
{
    public class Request
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

    }
}
