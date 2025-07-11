using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroCondorWS
{
    public class AsientoReservado
    {
        public int Id { get; set; }
        public int VueloId { get; set; }
        public int FacturaId { get; set; }
        public string NumeroAsiento { get; set; }
    }

}