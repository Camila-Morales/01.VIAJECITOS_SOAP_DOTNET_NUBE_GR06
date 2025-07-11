using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViajecitosSAClienteWeb.CondorService;

namespace ViajecitosSAClienteWeb.Models
{
    public class CompraVueloCompletaViewModel
    {
        public BuscarVueloViewModel Busqueda { get; set; } = new BuscarVueloViewModel();
        public Vuelo VueloSeleccionado { get; set; }
        public CompraConAsientosViewModel AsientosViewModel { get; set; }
        public ConfirmacionCompraViewModel Confirmacion { get; set; }
    }

}