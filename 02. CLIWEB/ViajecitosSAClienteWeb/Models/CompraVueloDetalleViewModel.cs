using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViajecitosSAClienteWeb.CondorService;

namespace ViajecitosSAClienteWeb.Models
{
    public class CompraVueloDetalleViewModel
    {
        public Vuelo Vuelo { get; set; }
        public int Cantidad { get; set; } = 1;

        public List<string> AsientosOcupados { get; set; }
        public string AsientosSeleccionadosRaw { get; set; }

        public string TipoPago { get; set; }
        public int NumeroCuotas { get; set; }
    }

}