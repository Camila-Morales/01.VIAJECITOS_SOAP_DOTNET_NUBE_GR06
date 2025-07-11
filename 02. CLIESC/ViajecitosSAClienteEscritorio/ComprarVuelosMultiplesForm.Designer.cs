namespace ViajecitosSAClienteEscritorio
{
    partial class ComprarVuelosMultiplesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridVuelos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.comboTipoPago = new System.Windows.Forms.ComboBox();
            this.numericCuotas = new System.Windows.Forms.NumericUpDown();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridVuelos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CIUDAD ORIGEN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(473, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CIUDAD DESTINO";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(247, 97);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(153, 22);
            this.txtOrigen.TabIndex = 2;
            this.txtOrigen.TextChanged += new System.EventHandler(this.txtOrigen_TextChanged);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(477, 97);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(163, 22);
            this.txtDestino.TabIndex = 3;
            this.txtDestino.TextChanged += new System.EventHandler(this.txtDestino_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(710, 56);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 49);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridVuelos
            // 
            this.gridVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVuelos.Location = new System.Drawing.Point(133, 154);
            this.gridVuelos.Name = "gridVuelos";
            this.gridVuelos.RowHeadersWidth = 51;
            this.gridVuelos.RowTemplate.Height = 24;
            this.gridVuelos.Size = new System.Drawing.Size(759, 131);
            this.gridVuelos.TabIndex = 5;
            this.gridVuelos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVuelos_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "CANTIDAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(691, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "TIPO PAGO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "CUOTAS";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(883, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 50);
            this.button1.TabIndex = 9;
            this.button1.Text = "COMPRAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(458, 430);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(133, 22);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // comboTipoPago
            // 
            this.comboTipoPago.FormattingEnabled = true;
            this.comboTipoPago.Location = new System.Drawing.Point(690, 375);
            this.comboTipoPago.Name = "comboTipoPago";
            this.comboTipoPago.Size = new System.Drawing.Size(109, 24);
            this.comboTipoPago.TabIndex = 11;
            this.comboTipoPago.SelectedIndexChanged += new System.EventHandler(this.comboTipoPago_SelectedIndexChanged);
            // 
            // numericCuotas
            // 
            this.numericCuotas.Location = new System.Drawing.Point(695, 488);
            this.numericCuotas.Name = "numericCuotas";
            this.numericCuotas.Size = new System.Drawing.Size(124, 22);
            this.numericCuotas.TabIndex = 12;
            this.numericCuotas.ValueChanged += new System.EventHandler(this.numericCuotas_ValueChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(473, 459);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(7, 16);
            this.lblMensaje.TabIndex = 13;
            this.lblMensaje.Text = "\r\n";
            // 
            // ComprarVuelosMultiplesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1053, 550);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.numericCuotas);
            this.Controls.Add(this.comboTipoPago);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridVuelos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComprarVuelosMultiplesForm";
            this.Text = "ComprarVuelosMultiplesForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridVuelos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView gridVuelos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox comboTipoPago;
        private System.Windows.Forms.NumericUpDown numericCuotas;
        private System.Windows.Forms.Label lblMensaje;
    }
}