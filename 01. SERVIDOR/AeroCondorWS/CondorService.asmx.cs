using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace AeroCondorWS
{
    [WebService(Namespace = "http://aerocondor.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CondorService : WebService
    {
        private readonly VueloService vueloService = new VueloService();

        [WebMethod]
        public List<Vuelo> ObtenerVuelos(string origen, string destino)
        {
            return vueloService.ObtenerVuelos(origen, destino);
        }

        [WebMethod]
        public string ComprarVuelo(int vueloId, int usuarioId)
        {
            return vueloService.ComprarVuelo(vueloId, usuarioId);
        }

        [WebMethod]
        public Vuelo ObtenerVueloPorId(int id)
        {
            return vueloService.ObtenerVueloPorId(id);
        }

        [WebMethod]
        public List<Vuelo> ObtenerVuelosPorFiltro(string tipoFiltro, string valor)
        {
            return vueloService.ObtenerVuelosPorUnFiltro(tipoFiltro, valor);
        }

        [WebMethod]
        public string Login(string username, string password)
        {
            return vueloService.Login(username, password);
        }

        [WebMethod]
        public string ComprarVueloConCantidad(int vueloId, int usuarioId, int cantidad)
        {
            return vueloService.ComprarVuelo(vueloId, usuarioId, cantidad);
        }

        [WebMethod]
        public Factura ObtenerFacturaPorId(int facturaId)
        {
            return vueloService.ObtenerFacturaPorId(facturaId);
        }

        [WebMethod]
        public string ComprarVuelosMultiples(VueloCompraRequest[] compras)
        {
            return vueloService.ComprarVuelosMultiples(compras.ToList());
        }

        [WebMethod]
        public Amortizacion[] ObtenerAmortizacionPorFacturaId(int facturaId)
        {
            return vueloService.ObtenerAmortizacionPorFacturaId(facturaId);
        }

        [WebMethod]
        public List<string> ObtenerAsientosOcupados(int vueloId)
        {
            return vueloService.ObtenerAsientosOcupados(vueloId);
        }

        [WebMethod]
        public string ComprarVueloConAsientos(int vueloId, int usuarioId, string[] asientosSeleccionados)
        {
            return vueloService.ComprarVueloConAsientos(vueloId, usuarioId, asientosSeleccionados);
        }
    }
}
