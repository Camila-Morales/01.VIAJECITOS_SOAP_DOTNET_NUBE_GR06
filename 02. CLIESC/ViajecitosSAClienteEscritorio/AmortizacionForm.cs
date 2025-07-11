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
    public partial class AmortizacionForm : Form
    {
        private readonly CondorServiceSoapClient client = new CondorServiceSoapClient();

        public AmortizacionForm()
        {
            InitializeComponent();
        }

        private void gridAmortizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerAmortizacion_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdFactura.Text, out int facturaId))
            {
                MessageBox.Show("Ingrese un ID de factura válido.");
                return;
            }

            try
            {
                var amortizaciones = client.ObtenerAmortizacionPorFacturaId(facturaId);

                if (amortizaciones == null || amortizaciones.Length == 0)
                {
                    MessageBox.Show("No hay tabla de amortización para esta factura.");
                    gridAmortizacion.DataSource = null;
                    return;
                }

                // Mostrar la tabla en el DataGridView
                gridAmortizacion.DataSource = amortizaciones;

                // Opcional: renombrar columnas si no están claras
                gridAmortizacion.Columns["NumeroCuota"].HeaderText = "Cuota";
                gridAmortizacion.Columns["FechaPago"].HeaderText = "Fecha de Pago";
                gridAmortizacion.Columns["MontoCuota"].HeaderText = "Monto";
                gridAmortizacion.Columns["Interes"].HeaderText = "Interés";
                gridAmortizacion.Columns["SaldoRestante"].HeaderText = "Saldo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la tabla de amortización: " + ex.Message);
            }
        }

        private void txtIdFactura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
