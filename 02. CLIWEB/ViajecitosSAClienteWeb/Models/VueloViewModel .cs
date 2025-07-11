using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajecitosSAClienteWeb.Models
{
    public class VueloViewModel
    {
        public int Id { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal Valor { get; set; }

        public string Descripcion => $"{CiudadOrigen} → {CiudadDestino} ({HoraSalida:HH:mm}) - ${Valor}";
    }

}