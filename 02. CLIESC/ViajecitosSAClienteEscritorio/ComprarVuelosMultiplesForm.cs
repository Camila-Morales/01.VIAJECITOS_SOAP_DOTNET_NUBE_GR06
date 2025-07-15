using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViajecitosSAClienteEscritorio.CondorService;

namespace ViajecitosSAClienteEscritorio
{
    public partial class ComprarVuelosMultiplesForm : Form
    {
        private readonly string usuario;
        private readonly CondorServiceSoapClient client = new CondorServiceSoapClient();
        private Vuelo[] vuelosDisponibles;
        private List<DateTime> fechasCompradas = new List<DateTime>();
        private Label lblAsientos;
        private CheckedListBox lstAsientos;

        public ComprarVuelosMultiplesForm(string usuarioLogueado)
        {
            InitializeComponent();
            usuario = usuarioLogueado;

            // Inicializar combo y cuotas
            comboTipoPago.Items.Add("EFECTIVO");
            comboTipoPago.Items.Add("CRÉDITO");
            comboTipoPago.SelectedIndex = 0;
            numericCuotas.Value = 1;

            // Suscripción al evento SelectionChanged
            this.gridVuelos.SelectionChanged += gridVuelos_SelectionChanged;

            // Asientos
            lblAsientos = new Label();
            lblAsientos.Text = "Seleccione los asientos:";
            lblAsientos.Location = new Point(20, 280);
            lblAsientos.AutoSize = true;
            this.Controls.Add(lblAsientos);

            lstAsientos = new CheckedListBox();
            lstAsientos.Name = "lstAsientos";
            lstAsientos.Location = new Point(20, 310);
            lstAsientos.Size = new Size(300, 120);
            this.Controls.Add(lstAsientos);
        }


        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDestino_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var origen = txtOrigen.Text.Trim().ToUpper();
            var destino = txtDestino.Text.Trim().ToUpper();

            vuelosDisponibles = client.ObtenerVuelos(origen, destino);

            if (vuelosDisponibles == null || vuelosDisponibles.Length == 0)
            {
                lblMensaje.Text = "No se encontraron vuelos.";
                gridVuelos.DataSource = null;
            }
            else
            {
                gridVuelos.DataSource = vuelosDisponibles;
                lblMensaje.Text = $"{vuelosDisponibles.Length} vuelo(s) encontrados.";
            }
        }

        //VALIDACION
        private void button1_Click(object sender, EventArgs e)
        {
            if (gridVuelos.CurrentRow == null)
            {
                lblMensaje.Text = "Selecciona un vuelo.";
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                lblMensaje.Text = "Ingrese una cantidad válida de boletos.";
                return;
            }

            if (!ValidarCantidadAsientos(cantidad))
                return;

            var tipoPago = comboTipoPago.SelectedItem.ToString();
            var cuotas = (int)numericCuotas.Value;
            var vuelo = (Vuelo)gridVuelos.CurrentRow.DataBoundItem;

            // ❗ Validar si ya se compró un vuelo en esa fecha
            DateTime fechaVuelo = vuelo.HoraSalida.Date;
            if (fechasCompradas.Contains(fechaVuelo))
            {
                MessageBox.Show("❌ Ya tiene una compra para esa fecha. No puede adquirir otro vuelo el mismo día.", "Fecha Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Convertir los asientos seleccionados a ArrayOfString
            var asientosSeleccionados = new ArrayOfString();
            asientosSeleccionados.AddRange(lstAsientos.CheckedItems.Cast<string>());

            var compra = new VueloCompraRequest
            {
                VueloId = vuelo.Id,
                UsuarioId = 1, // puedes reemplazar con lógica de sesión real
                Cantidad = cantidad,
                TipoPago = tipoPago,
                NumeroCuotas = tipoPago == "CREDITO" ? cuotas : 0,
                AsientosSeleccionados = asientosSeleccionados
            };

            try
            {
                string respuesta = client.ComprarVuelosMultiples(new[] { compra });
                MessageBox.Show("Resultado: " + respuesta, "Compra exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Guardamos la fecha para evitar futuras compras duplicadas
                fechasCompradas.Add(fechaVuelo);

                // Preguntar si desea comprar otro vuelo
                var continuar = MessageBox.Show("¿Desea comprar otro vuelo?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (continuar == DialogResult.Yes)
                {
                    // Limpiar campos para una nueva compra
                    txtCantidad.Text = "";
                    numericCuotas.Value = 1;
                    comboTipoPago.SelectedIndex = 0;
                    lstAsientos.Items.Clear();
                    lblMensaje.Text = "";
                }
                else
                {
                    this.Close(); // o puedes volver al menú principal
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la compra: " + ex.Message);
            }
        }


        private void gridVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericCuotas_ValueChanged(object sender, EventArgs e)
        {

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            if (gridVuelos.CurrentRow == null)
            {
                lblMensaje.Text = "Selecciona un vuelo.";
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                lblMensaje.Text = "Ingrese una cantidad válida de boletos.";
                return;
            }

            if (!ValidarCantidadAsientos(cantidad))
                return;

            var tipoPago = comboTipoPago.SelectedItem.ToString();
            var cuotas = (int)numericCuotas.Value;
            var vuelo = (Vuelo)gridVuelos.CurrentRow.DataBoundItem;

            // ✅ Convertir correctamente los asientos seleccionados a ArrayOfString
            var asientosSeleccionados = new ArrayOfString();
            asientosSeleccionados.AddRange(lstAsientos.CheckedItems.Cast<string>());

            var compra = new VueloCompraRequest
            {
                VueloId = vuelo.Id,
                UsuarioId = 1, // puedes reemplazar con lógica de sesión real
                Cantidad = cantidad,
                TipoPago = tipoPago,
                NumeroCuotas = tipoPago == "CREDITO" ? cuotas : 0,
                AsientosSeleccionados = asientosSeleccionados
            };

            try
            {
                string respuesta = client.ComprarVuelosMultiples(new[] { compra });
                MessageBox.Show("Resultado: " + respuesta, "Compra exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Preguntar si desea comprar otro vuelo
                var continuar = MessageBox.Show("¿Desea comprar otro vuelo?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (continuar == DialogResult.Yes)
                {
                    // Limpiar campos para una nueva compra
                    txtCantidad.Text = "";
                    numericCuotas.Value = 1;
                    comboTipoPago.SelectedIndex = 0;
                    lstAsientos.Items.Clear();
                    lblMensaje.Text = "";
                }
                else
                {
                    this.Close(); // o puedes volver al menú principal
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la compra: " + ex.Message);
            }

        }*/


        private List<string> GenerarAsientos()
        {
            var asientos = new List<string>();
            for (char fila = 'A'; fila <= 'F'; fila++)
            {
                for (int num = 1; num <= 6; num++)
                {
                    asientos.Add($"{fila}{num}");
                }
            }
            return asientos;
        }

        private void CargarAsientosDisponibles(int vueloId)
        {
            try
            {
                var ocupados = client.ObtenerAsientosOcupados(vueloId);
                var todos = GenerarAsientos();
                var disponibles = todos.Except(ocupados).ToList();

                lstAsientos.Items.Clear();
                foreach (var asiento in disponibles)
                {
                    lstAsientos.Items.Add(asiento);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los asientos: " + ex.Message);
            }
        }

        private void gridVuelos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVuelos.CurrentRow != null)
            {
                var vuelo = (Vuelo)gridVuelos.CurrentRow.DataBoundItem;
                CargarAsientosDisponibles(vuelo.Id);
            }
        }

        private bool ValidarCantidadAsientos(int cantidad)
        {
            if (lstAsientos.CheckedItems.Count != cantidad)
            {
                MessageBox.Show($"Debe seleccionar exactamente {cantidad} asiento(s).");
                return false;
            }
            return true;
        }

    }
}
