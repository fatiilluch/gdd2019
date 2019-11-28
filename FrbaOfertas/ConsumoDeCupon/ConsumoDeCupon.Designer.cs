namespace FrbaOfertas.ConsumoDeCupon
{
    partial class ConsumoDeCupon
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
            this.lblCuponId = new System.Windows.Forms.Label();
            this.txtCuponId = new System.Windows.Forms.TextBox();
            this.lblClienteDni = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateFechaConsumo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblCuponId
            // 
            this.lblCuponId.AutoSize = true;
            this.lblCuponId.Location = new System.Drawing.Point(22, 22);
            this.lblCuponId.Name = "lblCuponId";
            this.lblCuponId.Size = new System.Drawing.Size(88, 13);
            this.lblCuponId.TabIndex = 0;
            this.lblCuponId.Text = "Codigo de cupon";
            // 
            // txtCuponId
            // 
            this.txtCuponId.Location = new System.Drawing.Point(141, 22);
            this.txtCuponId.Name = "txtCuponId";
            this.txtCuponId.Size = new System.Drawing.Size(206, 20);
            this.txtCuponId.TabIndex = 1;
            // 
            // lblClienteDni
            // 
            this.lblClienteDni.AutoSize = true;
            this.lblClienteDni.Location = new System.Drawing.Point(22, 78);
            this.lblClienteDni.Name = "lblClienteDni";
            this.lblClienteDni.Size = new System.Drawing.Size(75, 13);
            this.lblClienteDni.TabIndex = 2;
            this.lblClienteDni.Text = "Dni del Cliente";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(22, 138);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(98, 13);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha de consumo";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(141, 78);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(206, 20);
            this.txtDni.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(45, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(227, 237);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(103, 23);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(22, 192);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(76, 13);
            this.lblCuit.TabIndex = 8;
            this.lblCuit.Text = "Cuit proveedor";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(141, 189);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(133, 20);
            this.txtCuit.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(280, 189);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateFechaConsumo
            // 
            this.dateFechaConsumo.Location = new System.Drawing.Point(141, 138);
            this.dateFechaConsumo.Name = "dateFechaConsumo";
            this.dateFechaConsumo.Size = new System.Drawing.Size(206, 20);
            this.dateFechaConsumo.TabIndex = 11;
            // 
            // ConsumoDeCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 272);
            this.Controls.Add(this.dateFechaConsumo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblClienteDni);
            this.Controls.Add(this.txtCuponId);
            this.Controls.Add(this.lblCuponId);
            this.Name = "ConsumoDeCupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsumoDeCupon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCuponId;
        private System.Windows.Forms.TextBox txtCuponId;
        private System.Windows.Forms.Label lblClienteDni;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateFechaConsumo;
    }
}