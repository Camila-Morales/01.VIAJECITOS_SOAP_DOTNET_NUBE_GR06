using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajecitosSAClienteWeb.Models
{
    public class CompraConAsientosViewModel
    {
        public int VueloId { get; set; }
        public List<string> AsientosOcupados { get; set; }
        public List<string> AsientosSeleccionados { get; set; }
    }
}