using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajecitosSAClienteWeb.Models
{
    public class VueloCompraRequestModel
    {
        public int VueloId { get; set; }
        public int Cantidad { get; set; }
        public string TipoPago { get; set; }
        public int NumeroCuotas { get; set; }
        public string AsientosSeleccionadosRaw { get; set; }
    }



}