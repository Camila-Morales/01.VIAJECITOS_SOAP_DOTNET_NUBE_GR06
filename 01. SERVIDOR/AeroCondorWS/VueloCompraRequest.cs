using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroCondorWS
{
    public class VueloCompraRequest
    {
        public int VueloId { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public string TipoPago { get; set; } // EFECTIVO o CREDITO
        public int NumeroCuotas { get; set; } // Solo usado si es crédito
        public string[] AsientosSeleccionados { get; set; }  // NUEVO atributo para los asientos
    }
}