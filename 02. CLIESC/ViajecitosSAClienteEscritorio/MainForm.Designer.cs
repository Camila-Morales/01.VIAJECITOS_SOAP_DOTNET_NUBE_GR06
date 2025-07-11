namespace ViajecitosSAClienteEscritorio
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscarVuelos = new System.Windows.Forms.Button();
            this.btnComprarVuelos = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btn_filtro = new System.Windows.Forms.Button();
            this.btn_Factura = new System.Windows.Forms.Button();
            this.btn_Amortizacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprarMultiples = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarVuelos
            // 
            this.btnBuscarVuelos.Location = new System.Drawing.Point(305, 157);
            this.btnBuscarVuelos.Name = "btnBuscarVuelos";
            this.btnBuscarVuelos.Size = new System.Drawing.Size(196, 79);
            this.btnBuscarVuelos.TabIndex = 0;
            this.btnBuscarVuelos.Text = "BUSCAR VUELOS";
            this.btnBuscarVuelos.UseVisualStyleBackColor = true;
            this.btnBuscarVuelos.Click += new System.EventHandler(this.btnBuscarVuelos_Click);
            // 
            // btnComprarVuelos
            // 
            this.btnComprarVuelos.Location = new System.Drawing.Point(522, 157);
            this.btnComprarVuelos.Name = "btnComprarVuelos";
            this.btnComprarVuelos.Size = new System.Drawing.Size(199, 79);
            this.btnComprarVuelos.TabIndex = 1;
            this.btnComprarVuelos.Text = "COMPRAR VUELO";
            this.btnComprarVuelos.UseVisualStyleBackColor = true;
            this.btnComprarVuelos.Click += new System.EventHandler(this.btnComprarVuelos_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(272, 83);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(0, 16);
            this.lblBienvenida.TabIndex = 2;
            // 
            // btn_filtro
            // 
            this.btn_filtro.Location = new System.Drawing.Point(92, 157);
            this.btn_filtro.Name = "btn_filtro";
            this.btn_filtro.Size = new System.Drawing.Size(196, 75);
            this.btn_filtro.TabIndex = 3;
            this.btn_filtro.Text = "BUSCAR POR FILTRO";
            this.btn_filtro.UseVisualStyleBackColor = true;
            this.btn_filtro.Click += new System.EventHandler(this.btn_filtro_Click);
            // 
            // btn_Factura
            // 
            this.btn_Factura.Location = new System.Drawing.Point(305, 255);
            this.btn_Factura.Name = "btn_Factura";
            this.btn_Factura.Size = new System.Drawing.Size(196, 79);
            this.btn_Factura.TabIndex = 4;
            this.btn_Factura.Text = "FACTURACIÓN";
            this.btn_Factura.UseVisualStyleBackColor = true;
            this.btn_Factura.Click += new System.EventHandler(this.btn_Factura_Click);
            // 
            // btn_Amortizacion
            // 
            this.btn_Amortizacion.Location = new System.Drawing.Point(522, 255);
            this.btn_Amortizacion.Name = "btn_Amortizacion";
            this.btn_Amortizacion.Size = new System.Drawing.Size(196, 79);
            this.btn_Amortizacion.TabIndex = 5;
            this.btn_Amortizacion.Text = "AMORTIZACIÓN";
            this.btn_Amortizacion.UseVisualStyleBackColor = true;
            this.btn_Amortizacion.Click += new System.EventHandler(this.btn_Amortizacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "MENÚ DE OPCIONES";
            // 
            // btnComprarMultiples
            // 
            this.btnComprarMultiples.Location = new System.Drawing.Point(92, 255);
            this.btnComprarMultiples.Name = "btnComprarMultiples";
            this.btnComprarMultiples.Size = new System.Drawing.Size(196, 79);
            this.btnComprarMultiples.TabIndex = 7;
            this.btnComprarMultiples.Text = "COMPRA VUELOS MÚLTIPLES";
            this.btnComprarMultiples.UseVisualStyleBackColor = true;
            this.btnComprarMultiples.Click += new System.EventHandler(this.btnComprarMultiples_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnComprarMultiples);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Amortizacion);
            this.Controls.Add(this.btn_Factura);
            this.Controls.Add(this.btn_filtro);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnComprarVuelos);
            this.Controls.Add(this.btnBuscarVuelos);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarVuelos;
        private System.Windows.Forms.Button btnComprarVuelos;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btn_filtro;
        private System.Windows.Forms.Button btn_Factura;
        private System.Windows.Forms.Button btn_Amortizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComprarMultiples;
    }
}