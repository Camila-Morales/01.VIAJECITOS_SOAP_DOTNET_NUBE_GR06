using System;
using System.Collections.Generic;
using System.Linq;
using ViajecitosSAClienteConsola.CondorService;

namespace ViajecitosSAClienteConsola
{
    class Program
    {
        static CondorServiceSoapClient client = new CondorServiceSoapClient();
        static int usuarioId = 1; // Puedes pedir esto luego del login
        static List<DateTime> fechasCompradas = new List<DateTime>();


        static void Main(string[] args)
        {
            Console.Title = "Viajecitos SA - Cliente Consola";
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("✈️  Bienvenido a Viajecitos SA");
                Console.WriteLine("1. Iniciar sesión");
                Console.WriteLine("2. Buscar vuelo por filtros");
                Console.WriteLine("3. Buscar vuelo más caro");
                Console.WriteLine("4. Comprar varios vuelos");
                Console.WriteLine("5. Ver factura");
                Console.WriteLine("6. Ver tabla de amortización");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        ListarVuelosConFiltros();
                        break;
                    case "3":
                        BuscarVuelos();
                        break;
                    case "4":
                        ComprarVuelosMultiples();
                        break;
                    case "5":
                        VerFactura();
                        break;
                    case "6":
                        VerAmortizacion();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("=== INICIAR SESIÓN ===");
            Console.Write("Usuario: ");
            var username = Console.ReadLine();
            Console.Write("Contraseña: ");
            var password = Console.ReadLine();

            var resultado = client.Login(username, password);
            Console.WriteLine("\n" + resultado);
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarVuelosConFiltros()
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR VUELOS CON FILTROS ===");
            Console.WriteLine("Seleccione el tipo de filtro:");
            Console.WriteLine("1. Ciudad de origen");
            Console.WriteLine("2. Ciudad de destino");
            Console.Write("Opción: ");
            var opcionFiltro = Console.ReadLine();

            string tipoFiltro = "";
            string valorFiltro = "";

            switch (opcionFiltro)
            {
                case "1":
                    tipoFiltro = "origen";
                    Console.Write("Ingrese la ciudad de origen (ej. UIO): ");
                    valorFiltro = Console.ReadLine().ToUpper();
                    break;

                case "2":
                    tipoFiltro = "destino";
                    Console.Write("Ingrese la ciudad de destino (ej. GYE): ");
                    valorFiltro = Console.ReadLine().ToUpper();
                    break;

                default:
                    Console.WriteLine("❌ Opción inválida.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    return;
            }

            // Llama al método correcto del servicio
            Vuelo[] vuelos = client.ObtenerVuelosPorFiltro(tipoFiltro, valorFiltro);

            if (vuelos == null || vuelos.Length == 0)
            {
                Console.WriteLine("\n❌ No se encontraron vuelos.");
            }
            else
            {
                Console.WriteLine($"\n🛫 Se encontraron {vuelos.Length} vuelo(s):");
                foreach (var vuelo in vuelos)
                {
                    Console.WriteLine($"ID: {vuelo.Id} | {vuelo.CiudadOrigen} -> {vuelo.CiudadDestino} | Hora: {vuelo.HoraSalida} | Valor: ${vuelo.Valor}");
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarVuelos()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR VUELOS ===");
            Console.Write("Ciudad Origen (ej. UIO): ");
            var origen = Console.ReadLine().ToUpper();
            Console.Write("Ciudad Destino (ej. GYE): ");
            var destino = Console.ReadLine().ToUpper();
            Console.Write("Fecha de viaje (yyyy-mm-dd): ");
            var fecha = Console.ReadLine();

            var vuelos = client.ObtenerVuelos(origen, destino);

            if (vuelos == null || vuelos.Length == 0)
            {
                Console.WriteLine("\n❌ Vuelo no disponible");
            }
            else
            {
                var vueloMayor = vuelos.OrderByDescending(v => v.Valor).First();
                Console.WriteLine("\n🛫 Vuelo más caro disponible:");
                Console.WriteLine($"ID: {vueloMayor.Id}");
                Console.WriteLine($"De: {vueloMayor.CiudadOrigen} a {vueloMayor.CiudadDestino}");
                Console.WriteLine($"Hora de salida: {vueloMayor.HoraSalida}");
                Console.WriteLine($"Precio: ${vueloMayor.Valor}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        /*static void ComprarVuelo()
        {
            Console.Clear();
            Console.WriteLine("=== COMPRAR VUELO ===");

            Console.Write("Ingrese el ID del vuelo que desea comprar: ");
            if (!int.TryParse(Console.ReadLine(), out int vueloId))
            {
                Console.WriteLine("ID de vuelo inválido.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese la cantidad de boletos a comprar: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad inválida.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Llamamos al servicio SOAP con la nueva firma que acepta cantidad
            string resultado = client.ComprarVueloConCantidad(vueloId, usuarioId, cantidad);

            Console.WriteLine("\n" + resultado);
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }*/

        static void VerFactura()
        {
            Console.Clear();
            Console.WriteLine("=== VER FACTURA POR ID ===");
            Console.Write("Ingrese el ID de la factura: ");
            if (int.TryParse(Console.ReadLine(), out int facturaId))
            {
                Factura factura = client.ObtenerFacturaPorId(facturaId);
                if (factura != null)
                {
                    Console.WriteLine("\n--- Detalles de la Factura ---");
                    Console.WriteLine($"ID Factura: {factura.Id}");
                    Console.WriteLine($"Usuario: {factura.NombreUsuario} (ID: {factura.UsuarioId})");
                    Console.WriteLine($"Edad: {factura.EdadUsuario}");
                    Console.WriteLine($"Nacionalidad: {factura.NacionalidadUsuario}");
                    Console.WriteLine($"Ciudad Origen: {factura.CiudadOrigen}");
                    Console.WriteLine($"Ciudad Destino: {factura.CiudadDestino}");
                    Console.WriteLine($"Hora Salida: {factura.HoraSalida}");
                    Console.WriteLine($"Cantidad de boletos: {factura.Cantidad}");
                    Console.WriteLine($"Precio Unitario: ${factura.PrecioUnitario:F2}");
                    Console.WriteLine($"Precio Total: ${factura.PrecioTotal:F2}");
                    Console.WriteLine($"Fecha Emisión: {factura.FechaEmision}");
                }
                else
                {
                    Console.WriteLine("Factura no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        /*static void ComprarVuelosMultiples()
        {
            var compras = new List<VueloCompraRequest>();

            bool seguirComprando = true;

            while (seguirComprando)
            {
                Console.Clear();
                Console.WriteLine("=== COMPRA DE VUELOS ===");

                Console.Write("Ingrese el ID del vuelo que desea comprar: ");
                if (!int.TryParse(Console.ReadLine(), out int vueloId))
                {
                    Console.WriteLine("ID de vuelo inválido.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Ingrese la cantidad de boletos a comprar: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                // Obtener asientos ocupados para este vuelo
                var asientosOcupados = client.ObtenerAsientosOcupados(vueloId).ToList();

                Console.WriteLine("Asientos ocupados actualmente: " + (asientosOcupados.Count == 0 ? "Ninguno" : string.Join(", ", asientosOcupados)));

                Console.WriteLine($"Seleccione exactamente {cantidad} asientos separados por coma (ejemplo: 1A,1B,2C):");
                var asientosInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(asientosInput))
                {
                    Console.WriteLine("No seleccionó ningún asiento.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                var asientosSeleccionados = asientosInput
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim().ToUpper())
                    .Distinct()
                    .ToList();

                if (asientosSeleccionados.Count != cantidad)
                {
                    Console.WriteLine($"Debe seleccionar exactamente {cantidad} asientos.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                // Validar que los asientos seleccionados no estén ocupados
                bool asientoOcupado = asientosSeleccionados.Any(a => asientosOcupados.Contains(a));
                if (asientoOcupado)
                {
                    Console.WriteLine("Alguno de los asientos seleccionados ya está ocupado. Operación cancelada.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Tipo de pago (EFECTIVO/CREDITO): ");
                string tipoPago = Console.ReadLine().Trim().ToUpper();
                if (tipoPago != "EFECTIVO" && tipoPago != "CREDITO")
                {
                    Console.WriteLine("Tipo de pago inválido.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                int numeroCuotas = 0;
                if (tipoPago == "CREDITO")
                {
                    Console.Write("Número de cuotas (mínimo 1): ");
                    if (!int.TryParse(Console.ReadLine(), out numeroCuotas) || numeroCuotas < 1)
                    {
                        Console.WriteLine("Número de cuotas inválido.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        continue;
                    }
                }

                compras.Add(new VueloCompraRequest
                {
                    VueloId = vueloId,
                    UsuarioId = usuarioId,
                    Cantidad = cantidad,
                    TipoPago = tipoPago,
                    NumeroCuotas = numeroCuotas,
                    AsientosSeleccionados = new ArrayOfString()
                });

                // Agregar los asientos seleccionados a ArrayOfString
                foreach (var asiento in asientosSeleccionados)
                {
                    compras.Last().AsientosSeleccionados.Add(asiento);
                }

                Console.Write("¿Desea agregar otro vuelo? (S/N): ");
                var respuesta = Console.ReadLine().Trim().ToUpper();
                if (respuesta != "S")
                    seguirComprando = false;
            }

            // Llamada al servicio
            string resultado = client.ComprarVuelosMultiples(compras.ToArray());

            // Mostrar asientos seleccionados
            var asientosElegidos = compras.SelectMany(c => c.AsientosSeleccionados).Distinct().ToList();
            string mensajeAsientos = asientosElegidos.Count > 0
                ? "Asientos seleccionados: " + string.Join(", ", asientosElegidos)
                : "No se seleccionaron asientos.";

            Console.WriteLine("\n" + resultado);
            Console.WriteLine(mensajeAsientos);
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }*/

        static void ComprarVuelosMultiples()
        {
            var compras = new List<VueloCompraRequest>();
            bool seguirComprando = true;

            while (seguirComprando)
            {
                Console.Clear();
                Console.WriteLine("=== COMPRA DE VUELOS ===");

                Console.Write("Ingrese el ID del vuelo que desea comprar: ");
                if (!int.TryParse(Console.ReadLine(), out int vueloId))
                {
                    Console.WriteLine("ID de vuelo inválido.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                // Obtener vuelo para validar fecha
                var vuelo = client.ObtenerVueloPorId(vueloId); // Asegúrate de tener este método en el backend
                DateTime fechaVuelo = vuelo.HoraSalida.Date;

                if (fechasCompradas.Contains(fechaVuelo))
                {
                    Console.WriteLine("❌ Ya tiene un vuelo registrado para esta fecha. No puede comprar otro.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Ingrese la cantidad de boletos a comprar: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                var asientosOcupados = client.ObtenerAsientosOcupados(vueloId).ToList();
                Console.WriteLine("Asientos ocupados actualmente: " + (asientosOcupados.Count == 0 ? "Ninguno" : string.Join(", ", asientosOcupados)));

                Console.WriteLine($"Seleccione exactamente {cantidad} asientos separados por coma (ejemplo: A1,A2,B3):");
                var asientosInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(asientosInput))
                {
                    Console.WriteLine("No seleccionó ningún asiento.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                var asientosSeleccionados = asientosInput
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim().ToUpper())
                    .Distinct()
                    .ToList();

                if (asientosSeleccionados.Count != cantidad)
                {
                    Console.WriteLine($"Debe seleccionar exactamente {cantidad} asientos.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (asientosSeleccionados.Any(a => asientosOcupados.Contains(a)))
                {
                    Console.WriteLine("Alguno de los asientos seleccionados ya está ocupado. Operación cancelada.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Tipo de pago (EFECTIVO/CREDITO): ");
                string tipoPago = Console.ReadLine().Trim().ToUpper();
                if (tipoPago != "EFECTIVO" && tipoPago != "CREDITO")
                {
                    Console.WriteLine("Tipo de pago inválido.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                int numeroCuotas = 0;
                if (tipoPago == "CREDITO")
                {
                    Console.Write("Número de cuotas (mínimo 1): ");
                    if (!int.TryParse(Console.ReadLine(), out numeroCuotas) || numeroCuotas < 1)
                    {
                        Console.WriteLine("Número de cuotas inválido.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        continue;
                    }
                }

                var compra = new VueloCompraRequest
                {
                    VueloId = vueloId,
                    UsuarioId = usuarioId,
                    Cantidad = cantidad,
                    TipoPago = tipoPago,
                    NumeroCuotas = numeroCuotas,
                    AsientosSeleccionados = new ArrayOfString()
                };

                foreach (var asiento in asientosSeleccionados)
                {
                    compra.AsientosSeleccionados.Add(asiento);
                }

                compras.Add(compra);

                // ✅ Guardamos la fecha para evitar futuras compras duplicadas en esta sesión
                fechasCompradas.Add(fechaVuelo);

                Console.Write("¿Desea agregar otro vuelo? (S/N): ");
                var respuesta = Console.ReadLine().Trim().ToUpper();
                if (respuesta != "S")
                    seguirComprando = false;
            }

            string resultado = client.ComprarVuelosMultiples(compras.ToArray());

            var asientosElegidos = compras.SelectMany(c => c.AsientosSeleccionados).Distinct().ToList();
            string mensajeAsientos = asientosElegidos.Count > 0
                ? "Asientos seleccionados: " + string.Join(", ", asientosElegidos)
                : "No se seleccionaron asientos.";

            Console.WriteLine("\n" + resultado);
            Console.WriteLine(mensajeAsientos);
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }



        static void VerAmortizacion()
        {
            Console.Clear();
            Console.WriteLine("=== VER TABLA DE AMORTIZACIÓN POR FACTURA ===");
            Console.Write("Ingrese el ID de la factura: ");

            if (int.TryParse(Console.ReadLine(), out int facturaId))
            {
                var amortizaciones = client.ObtenerAmortizacionPorFacturaId(facturaId);

                if (amortizaciones != null && amortizaciones.Length > 0)
                {
                    Console.WriteLine("\n--- Tabla de Amortización ---");
                    Console.WriteLine($"{"Cuota",5} | {"Monto",10} | {"Saldo",10} | {"Fecha Pago",12}");
                    Console.WriteLine(new string('-', 45));

                    foreach (var a in amortizaciones)
                    {
                        Console.WriteLine($"{a.NumeroCuota,5} | ${a.MontoCuota,8:F2} | ${a.SaldoRestante,8:F2} | {a.FechaPago:yyyy-MM-dd}");
                    }
                }
                else
                {
                    Console.WriteLine("❌ No se encontraron registros de amortización para esta factura.");
                }
            }
            else
            {
                Console.WriteLine("❌ ID inválido.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
