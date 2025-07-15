using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajecitosSAClienteWeb.Models
{
    public class CompraVueloMultipleViewModel
    {
        public List<VueloViewModel> VuelosDisponibles { get; set; }
        public List<VueloCompraRequestModel> Compras { get; set; } = new List<VueloCompraRequestModel>();

        // Propiedades para el vuelo actual que se quiere agregar
        public int VueloSeleccionadoId { get; set; }
        public int CantidadBoletos { get; set; } = 1;
        public string TipoPago { get; set; } = "EFECTIVO";
        public int NumeroCuotas { get; set; }
        public string AsientosSeleccionadosRaw { get; set; }
    }

}