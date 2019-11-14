namespace FrbaOfertas.AbmProveedor
{
    partial class BajaProveedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.lblIdProveedor = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdProveedor);
            this.groupBox1.Controls.Add(this.lblIdProveedor);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar un Proveedor";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Location = new System.Drawing.Point(274, 35);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(120, 20);
            this.txtIdProveedor.TabIndex = 0;
            // 
            // lblIdProveedor
            // 
            this.lblIdProveedor.AutoSize = true;
            this.lblIdProveedor.Location = new System.Drawing.Point(20, 35);
            this.lblIdProveedor.Name = "lblIdProveedor";
            this.lblIdProveedor.Size = new System.Drawing.Size(226, 13);
            this.lblIdProveedor.TabIndex = 0;
            this.lblIdProveedor.Text = "Ingrese el Id del Proveedor que desea Eliminar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnEliminar.Location = new System.Drawing.Point(233, 65);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 39);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar Proveedor";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnCancelar.Location = new System.Drawing.Point(23, 65);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 39);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // BajaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 145);
            this.Controls.Add(this.groupBox1);
            this.Name = "BajaProveedor";
            this.Text = "BajaProveedor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdProveedor;
        private System.Windows.Forms.Label lblIdProveedor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
    }
}