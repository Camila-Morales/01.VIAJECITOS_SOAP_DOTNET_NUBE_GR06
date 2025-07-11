using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajecitosSAClienteWeb.Models
{
    public class Amortizacion
    {
        public int NumeroCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal SaldoRestante { get; set; }
    }


}