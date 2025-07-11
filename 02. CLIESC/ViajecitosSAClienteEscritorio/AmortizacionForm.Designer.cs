namespace ViajecitosSAClienteEscritorio
{
    partial class AmortizacionForm
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
            this.gridAmortizacion = new System.Windows.Forms.DataGridView();
            this.lblAmortizacion = new System.Windows.Forms.Label();
            this.btnVerAmortizacion = new System.Windows.Forms.Button();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmortizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAmortizacion
            // 
            this.gridAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAmortizacion.Location = new System.Drawing.Point(12, 165);
            this.gridAmortizacion.Name = "gridAmortizacion";
            this.gridAmortizacion.ReadOnly = true;
            this.gridAmortizacion.RowHeadersWidth = 51;
            this.gridAmortizacion.RowTemplate.Height = 24;
            this.gridAmortizacion.Size = new System.Drawing.Size(776, 159);
            this.gridAmortizacion.TabIndex = 0;
            this.gridAmortizacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAmortizacion_CellContentClick);
            // 
            // lblAmortizacion
            // 
            this.lblAmortizacion.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lblAmortizacion.AutoSize = true;
            this.lblAmortizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmortizacion.Location = new System.Drawing.Point(287, 61);
            this.lblAmortizacion.Name = "lblAmortizacion";
            this.lblAmortizacion.Size = new System.Drawing.Size(207, 22);
            this.lblAmortizacion.TabIndex = 1;
            this.lblAmortizacion.Text = "Tabla de amortización";
            // 
            // btnVerAmortizacion
            // 
            this.btnVerAmortizacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerAmortizacion.Location = new System.Drawing.Point(449, 98);
            this.btnVerAmortizacion.Name = "btnVerAmortizacion";
            this.btnVerAmortizacion.Size = new System.Drawing.Size(156, 49);
            this.btnVerAmortizacion.TabIndex = 2;
            this.btnVerAmortizacion.Text = "Ver amortización";
            this.btnVerAmortizacion.UseVisualStyleBackColor = true;
            this.btnVerAmortizacion.Click += new System.EventHandler(this.btnVerAmortizacion_Click);
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(137, 111);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(278, 22);
            this.txtIdFactura.TabIndex = 3;
            this.txtIdFactura.TextChanged += new System.EventHandler(this.txtIdFactura_TextChanged);
            // 
            // AmortizacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtIdFactura);
            this.Controls.Add(this.btnVerAmortizacion);
            this.Controls.Add(this.lblAmortizacion);
            this.Controls.Add(this.gridAmortizacion);
            this.Name = "AmortizacionForm";
            this.Text = "AmortizacionForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridAmortizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAmortizacion;
        private System.Windows.Forms.Label lblAmortizacion;
        private System.Windows.Forms.Button btnVerAmortizacion;
        private System.Windows.Forms.TextBox txtIdFactura;
    }
}