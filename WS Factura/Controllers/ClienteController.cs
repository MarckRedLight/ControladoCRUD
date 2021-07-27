using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_Factura.Models;
using WS_Factura.Models.View;
using WS_Factura.Models.Respuestas;

namespace WS_Factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            Request Respuesta = new Request();
            Respuesta.Exito = 0;
            try
            {
                using (FacturasContext db = new FacturasContext())
                {
                    var lst = db.Clientes.OrderByDescending(d=>d.Nit).ToList();
                    Respuesta.Exito = 1;
                    Respuesta.Data = lst;
                    
                }
            }
            catch (Exception ex)
            {
                Respuesta.Mensaje = ex.Message;
            }
            return Ok(Respuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteView oModel)
        {
            Request Respuesta = new Request();
            Respuesta.Exito = 0;
            try
            {
                using (FacturasContext db = new FacturasContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nit = oModel.Nit;
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Apellido = oModel.Apellido;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    Respuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                Respuesta.Mensaje = ex.Message;
            }
            return Ok(Respuesta);
        }


        [HttpPut]
        public IActionResult Edit(ClienteView oModel)
        {
            Request oRespuesta = new Request();
            oRespuesta.Exito = 0;
            try
            {
                using (FacturasContext db = new FacturasContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Nit);
                    oCliente.Nit = oModel.Nit;
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Apellido = oModel.Apellido;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpDelete("{nit}")]
        public IActionResult Delete(long nit)
        {
            Request oRespuesta = new Request();
            oRespuesta.Exito = 0;
            try
            {
                using (FacturasContext db = new FacturasContext())
                {
                    Cliente oCliente = db.Clientes.Find(nit);
                    db.Remove(oCliente);                   
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
 
}
