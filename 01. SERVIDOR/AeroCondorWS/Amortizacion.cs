using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroCondorWS
{
    public class Amortizacion
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int NumeroCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal SaldoRestante { get; set; }
        public DateTime FechaPago { get; set; }
    }

}