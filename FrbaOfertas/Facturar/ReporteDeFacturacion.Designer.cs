namespace FrbaOfertas.Facturar
{
    partial class ReporteDeFacturacion
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
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateFechaMinima = new System.Windows.Forms.DateTimePicker();
            this.dateFechaMaxima = new System.Windows.Forms.DateTimePicker();
            this.lblFechaMinima = new System.Windows.Forms.Label();
            this.lblFechaMaxima = new System.Windows.Forms.Label();
            this.dgOfertasAFacturar = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgOfertasAFacturar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(132, 21);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(196, 20);
            this.txtCuit.TabIndex = 0;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(29, 24);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(76, 13);
            this.lblCuit.TabIndex = 1;
            this.lblCuit.Text = "Cuit proveedor";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(352, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dateFechaMinima
            // 
            this.dateFechaMinima.Location = new System.Drawing.Point(26, 44);
            this.dateFechaMinima.Name = "dateFechaMinima";
            this.dateFechaMinima.Size = new System.Drawing.Size(200, 20);
            this.dateFechaMinima.TabIndex = 4;
            // 
            // dateFechaMaxima
            // 
            this.dateFechaMaxima.Location = new System.Drawing.Point(320, 44);
            this.dateFechaMaxima.Name = "dateFechaMaxima";
            this.dateFechaMaxima.Size = new System.Drawing.Size(200, 20);
            this.dateFechaMaxima.TabIndex = 5;
            // 
            // lblFechaMinima
            // 
            this.lblFechaMinima.AutoSize = true;
            this.lblFechaMinima.Location = new System.Drawing.Point(23, 28);
            this.lblFechaMinima.Name = "lblFechaMinima";
            this.lblFechaMinima.Size = new System.Drawing.Size(73, 13);
            this.lblFechaMinima.TabIndex = 6;
            this.lblFechaMinima.Text = "Fecha Minima";
            // 
            // lblFechaMaxima
            // 
            this.lblFechaMaxima.AutoSize = true;
            this.lblFechaMaxima.Location = new System.Drawing.Point(319, 28);
            this.lblFechaMaxima.Name = "lblFechaMaxima";
            this.lblFechaMaxima.Size = new System.Drawing.Size(76, 13);
            this.lblFechaMaxima.TabIndex = 7;
            this.lblFechaMaxima.Text = "Fecha Maxima";
            // 
            // dgOfertasAFacturar
            // 
            this.dgOfertasAFacturar.AllowUserToAddRows = false;
            this.dgOfertasAFacturar.AllowUserToDeleteRows = false;
            this.dgOfertasAFacturar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOfertasAFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOfertasAFacturar.Location = new System.Drawing.Point(32, 156);
            this.dgOfertasAFacturar.MultiSelect = false;
            this.dgOfertasAFacturar.Name = "dgOfertasAFacturar";
            this.dgOfertasAFacturar.ReadOnly = true;
            this.dgOfertasAFacturar.Size = new System.Drawing.Size(559, 254);
            this.dgOfertasAFacturar.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(32, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(516, 429);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 10;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateFechaMinima);
            this.groupBox1.Controls.Add(this.dateFechaMaxima);
            this.groupBox1.Controls.Add(this.lblFechaMinima);
            this.groupBox1.Controls.Add(this.lblFechaMaxima);
            this.groupBox1.Location = new System.Drawing.Point(32, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intervalo de fechas";
            // 
            // ReporteDeFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgOfertasAFacturar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.txtCuit);
            this.Name = "ReporteDeFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Facturacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteDeFacturacion_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgOfertasAFacturar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateFechaMinima;
        private System.Windows.Forms.DateTimePicker dateFechaMaxima;
        private System.Windows.Forms.Label lblFechaMinima;
        private System.Windows.Forms.Label lblFechaMaxima;
        private System.Windows.Forms.DataGridView dgOfertasAFacturar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}