namespace FrbaOfertas.CragaCredito
{
    partial class CargaCredito
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtTarjetaTitular = new System.Windows.Forms.TextBox();
            this.txtTarjeta_id = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.lblFechaVto = new System.Windows.Forms.Label();
            this.lblTarjetaId = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.calendario = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(22, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(192, 235);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(123, 20);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(200, 20);
            this.txtMonto.TabIndex = 2;
            // 
            // txtTarjetaTitular
            // 
            this.txtTarjetaTitular.Location = new System.Drawing.Point(123, 138);
            this.txtTarjetaTitular.Name = "txtTarjetaTitular";
            this.txtTarjetaTitular.Size = new System.Drawing.Size(200, 20);
            this.txtTarjetaTitular.TabIndex = 3;
            // 
            // txtTarjeta_id
            // 
            this.txtTarjeta_id.Location = new System.Drawing.Point(123, 96);
            this.txtTarjeta_id.Name = "txtTarjeta_id";
            this.txtTarjeta_id.Size = new System.Drawing.Size(200, 20);
            this.txtTarjeta_id.TabIndex = 6;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(18, 23);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(37, 13);
            this.lblMonto.TabIndex = 10;
            this.lblMonto.Text = "Monto";
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.Location = new System.Drawing.Point(18, 56);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(75, 13);
            this.lblTipoTarjeta.TabIndex = 11;
            this.lblTipoTarjeta.Text = "Tipo de tarjeta";
            // 
            // lblFechaVto
            // 
            this.lblFechaVto.AutoSize = true;
            this.lblFechaVto.Location = new System.Drawing.Point(19, 183);
            this.lblFechaVto.Name = "lblFechaVto";
            this.lblFechaVto.Size = new System.Drawing.Size(74, 13);
            this.lblFechaVto.TabIndex = 12;
            this.lblFechaVto.Text = "Fecha de Vto.";
            // 
            // lblTarjetaId
            // 
            this.lblTarjetaId.AutoSize = true;
            this.lblTarjetaId.Location = new System.Drawing.Point(18, 99);
            this.lblTarjetaId.Name = "lblTarjetaId";
            this.lblTarjetaId.Size = new System.Drawing.Size(91, 13);
            this.lblTarjetaId.TabIndex = 15;
            this.lblTarjetaId.Text = "Numero de tarjeta";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(19, 138);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(36, 13);
            this.lblTitular.TabIndex = 16;
            this.lblTitular.Text = "Titular";
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(123, 56);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoTarjeta.TabIndex = 17;
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(123, 183);
            this.calendario.Name = "calendario";
            this.calendario.Size = new System.Drawing.Size(200, 20);
            this.calendario.TabIndex = 19;
            this.calendario.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 279);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.cmbTipoTarjeta);
            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.lblTarjetaId);
            this.Controls.Add(this.lblFechaVto);
            this.Controls.Add(this.lblTipoTarjeta);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtTarjeta_id);
            this.Controls.Add(this.txtTarjetaTitular);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "CargaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de credito";
            this.Load += new System.EventHandler(this.CargaCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtTarjetaTitular;
        private System.Windows.Forms.TextBox txtTarjeta_id;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.Label lblFechaVto;
        private System.Windows.Forms.Label lblTarjetaId;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.ComboBox cmbTipoTarjeta;
        private System.Windows.Forms.DateTimePicker calendario;
    }
}