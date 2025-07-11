using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViajecitosSAClienteWeb.CondorService;
using ViajecitosSAClienteWeb.Models;
using FacturaModel = ViajecitosSAClienteWeb.Models.Factura;
using System.Text.RegularExpressions;



namespace ViajecitosSAClienteWeb.Controllers
{
    public class VueloController : Controller
    {
        private CondorServiceSoapClient client = new CondorServiceSoapClient();

        public ActionResult Buscar()
        {
            var vuelos = client.ObtenerVuelos("", ""); // trae todos
            var vueloMayorValor = vuelos?.OrderByDescending(v => v.Valor).FirstOrDefault();

            var model = new BuscarVueloViewModel
            {
                Resultados = vueloMayorValor != null ? new List<Vuelo> { vueloMayorValor } : new List<Vuelo>()
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Buscar(CompraVueloCompletaViewModel model)
        {
            var origen = string.IsNullOrWhiteSpace(model.Busqueda?.CiudadOrigen) ? "" : model.Busqueda ?.CiudadOrigen.ToUpper();
            var destino = string.IsNullOrWhiteSpace(model.Busqueda?.CiudadDestino) ? "" : model.Busqueda?.CiudadDestino.ToUpper();

            var vuelos = client.ObtenerVuelos(origen, destino).ToList() ?? new List<Vuelo>();

            var vueloMayorValor = vuelos?.OrderByDescending(v => v.Valor).FirstOrDefault();

            model.Busqueda.Resultados = vueloMayorValor != null ? new List<Vuelo> { vueloMayorValor } : new List<Vuelo>();

            if (!model.Busqueda.Resultados.Any())
                ViewBag.Mensaje = "No se encontraron vuelos con esos criterios.";

            return View("ComprarVuelosMultiples", model);
        }

        /*[HttpPost]
        public ActionResult Buscar(CompraVueloCompletaViewModel model)
        {
            var origen = model.Busqueda?.CiudadOrigen?.ToUpper() ?? "";
            var destino = model.Busqueda?.CiudadDestino?.ToUpper() ?? "";

            var vuelos = client.ObtenerVuelos(origen, destino)?.ToList() ?? new List<Vuelo>();

            model.Busqueda.Resultados = vuelos;

            return View("ComprarVuelosMultiples", model);
        }*/


        [HttpPost]
        public ActionResult Resultado(BuscarVueloViewModel model)
        {
            var vuelos = client.ObtenerVuelos(model.CiudadOrigen, model.CiudadDestino);
            if (vuelos == null || vuelos.Length == 0)
            {
                ViewBag.Mensaje = "Vuelo no Disponible";
                return View("Resultado");
            }

            var vueloMayorValor = vuelos.OrderByDescending(v => v.Valor).First();
            return View("Resultado", vueloMayorValor);
        }

        public ActionResult Comprar(int id)
        {
            var vuelo = client.ObtenerVueloPorId(id);

            if (vuelo == null)
            {
                ViewBag.Mensaje = "No se encontró el vuelo";
                return RedirectToAction("Buscar");
            }

            return View(vuelo);
        }


        [HttpPost]
        public ActionResult ConfirmarCompra(int vueloId, int cantidad)
        {
            var cliente = new CondorService.CondorServiceSoapClient();
            int usuarioId = 1; // Aquí deberías usar el ID del usuario logueado

            string mensaje = cliente.ComprarVueloConCantidad(vueloId, usuarioId, cantidad);
            var vuelo = cliente.ObtenerVueloPorId(vueloId);

            var modelo = new ConfirmacionCompraViewModel
            {
                Vuelo = vuelo,
                Mensaje = mensaje,
                Cantidad = cantidad
            };

            return View("Confirmacion", modelo);
        }


        public ActionResult BuscarPorFiltro()
        {
            return View(new BuscarVueloViewModel());
        }

        [HttpPost]
        public ActionResult BuscarPorFiltro(BuscarVueloViewModel model, string tipoFiltro)
        {
            if (string.IsNullOrWhiteSpace(tipoFiltro) || string.IsNullOrWhiteSpace(model.ValorFiltro))
            {
                ViewBag.Mensaje = "Debe ingresar un tipo de filtro y un valor.";
                return View(model);
            }

            var vuelos = client.ObtenerVuelosPorFiltro(tipoFiltro, model.ValorFiltro);
            model.Resultados = vuelos?.ToList() ?? new List<Vuelo>();

            if (!model.Resultados.Any())
                ViewBag.Mensaje = "No se encontraron vuelos con ese filtro.";

            return View(model);
        }

        [HttpGet]
        public ActionResult VerFactura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerFactura(int facturaId)
        {
            var client = new CondorService.CondorServiceSoapClient();
            var facturaDTO = client.ObtenerFacturaPorId(facturaId);

            if (facturaDTO == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna factura con ese ID.";
                return View();
            }

            var factura = new FacturaModel
            {
                Id = facturaDTO.Id,
                UsuarioId = facturaDTO.UsuarioId,
                NombreUsuario = facturaDTO.NombreUsuario,
                EdadUsuario = facturaDTO.EdadUsuario,
                NacionalidadUsuario = facturaDTO.NacionalidadUsuario,
                CiudadOrigen = facturaDTO.CiudadOrigen,
                CiudadDestino = facturaDTO.CiudadDestino,
                HoraSalida = facturaDTO.HoraSalida,
                Cantidad = facturaDTO.Cantidad,
                PrecioUnitario = facturaDTO.PrecioUnitario,
                PrecioTotal = facturaDTO.PrecioTotal,
                FechaEmision = facturaDTO.FechaEmision
            };

            return View(factura);
        }

        //NUEVOS METODOS - AMORTIZACION - COMPRA VARIOS VUELOS - SELECCIONAR ASIENTO - VALIDAR ASIENTOS OCUPADOS //

        [HttpGet]
        public ActionResult ComprarVuelosMultiples()
        {
            var model = new CompraVueloCompletaViewModel
            {
                Busqueda = new BuscarVueloViewModel
                {
                    CiudadOrigen = "",
                    CiudadDestino = "",
                    Fecha = DateTime.Today,
                    Resultados = new List<CondorService.Vuelo>()
                },
                AsientosViewModel = null,
                Confirmacion = null
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ComprarVuelosMultiples(List<VueloCompraRequestModel> compras)
        {
            var solicitudes = new List<CondorService.VueloCompraRequest>();

            foreach (var compra in compras)
            {
                var asientosSeleccionados = compra.AsientosSeleccionadosRaw
                    ?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim().ToUpper())
                    .Distinct()
                    .ToArray();

                var arrayOfString = new CondorService.ArrayOfString();
                arrayOfString.AddRange(asientosSeleccionados);

                solicitudes.Add(new CondorService.VueloCompraRequest
                {
                    VueloId = compra.VueloId,
                    UsuarioId = 1, // reemplazar si tienes autenticación
                    Cantidad = compra.Cantidad,
                    TipoPago = compra.TipoPago,
                    NumeroCuotas = compra.NumeroCuotas,
                    AsientosSeleccionados = arrayOfString
                });
            }

            try
            {
                string resultado = client.ComprarVuelosMultiples(solicitudes.ToArray());

                var idExtraido = Regex.Match(resultado, @"\d+").Value;
                int facturaId;
                if (!int.TryParse(idExtraido, out facturaId))
                {
                    ViewBag.Mensaje = "Error al procesar la compra. Respuesta: " + resultado;
                    return View("ComprarVuelosMultiples", new CompraVueloCompletaViewModel());
                }

                ViewBag.Mensaje = $"Compra realizada con éxito. Número de factura: {facturaId}";
                ViewBag.FacturaId = facturaId;
                ViewBag.PreguntarOtraCompra = true;

                return View("ComprarVuelosMultiples", new CompraVueloCompletaViewModel());
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error inesperado: " + ex.Message;
                return View("ComprarVuelosMultiples", new CompraVueloCompletaViewModel());
            }
        }


        public ActionResult ResumenCompra(int? facturaId)
        {
            if (!facturaId.HasValue)
            {
                return RedirectToAction("ComprarVuelosMultiples");
            }

            var facturaServicio = client.ObtenerFacturaPorId(facturaId.Value);

            var factura = new Models.Factura
            {
                Id = facturaServicio.Id,
                NombreUsuario = facturaServicio.NombreUsuario,
                CiudadOrigen = facturaServicio.CiudadOrigen,
                CiudadDestino = facturaServicio.CiudadDestino,
                HoraSalida = facturaServicio.HoraSalida,
                PrecioUnitario = facturaServicio.PrecioUnitario,
                Cantidad = facturaServicio.Cantidad,
                PrecioTotal = facturaServicio.PrecioTotal
            };

            var viewModel = new ConfirmacionCompraViewModel
            {
                Factura = factura,
                Mensaje = "Compra registrada correctamente."
            };

            return View("Confirmacion", viewModel);
        }

        [HttpGet]
        public ActionResult VerAmortizacion(int facturaId)
        {
            var amortizacionesServicio = client.ObtenerAmortizacionPorFacturaId(facturaId);

            var amortizaciones = amortizacionesServicio.Select(a => new Models.Amortizacion
            {
                NumeroCuota = a.NumeroCuota,
                FechaPago = a.FechaPago,
                MontoCuota = a.MontoCuota,
                SaldoRestante = a.SaldoRestante,
            }).ToList();

            return View(amortizaciones);
        }

        [HttpGet]
        public JsonResult ObtenerAsientosOcupados(int vueloId)
        {
            var asientos = client.ObtenerAsientosOcupados(vueloId);
            return Json(asientos.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ComprarConAsientos(int vueloId)
        {
            var asientosOcupados = client.ObtenerAsientosOcupados(vueloId);
            var model = new CompraConAsientosViewModel
            {
                VueloId = vueloId,
                AsientosOcupados = asientosOcupados?.ToList() ?? new List<string>()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ComprarVueloConAsientos(int vueloId, string asientosInput)
        {
            var asientosSeleccionados = asientosInput
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim().ToUpper())
                .Distinct()
                .ToArray();

            var arrayOfString = new CondorService.ArrayOfString();
            arrayOfString.AddRange(asientosSeleccionados);

            var resultado = client.ComprarVueloConAsientos(vueloId, 1, arrayOfString); // Cambia 1 por el usuario real

            ViewBag.Mensaje = resultado;
            return View("Confirmacion");
        }
    }
}