namespace FrbaOfertas.CrearOferta
{
    partial class altaOferta
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
            this.components = new System.ComponentModel.Container();
            this.lblId = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblLimiteCompra = new System.Windows.Forms.Label();
            this.lblprecioAntiguo = new System.Windows.Forms.Label();
            this.lblPrecioNuevo = new System.Windows.Forms.Label();
            this.lblIdProveedor = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.lblPublicacion = new System.Windows.Forms.Label();
            this.groupBoxFechas = new System.Windows.Forms.GroupBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtLimiteCompra = new System.Windows.Forms.TextBox();
            this.txtPrecioAntiguo = new System.Windows.Forms.TextBox();
            this.txtPrecioNuevo = new System.Windows.Forms.TextBox();
            this.txtIdProv = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.validator = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.validator)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(679, 410);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 27);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(12, 58);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(35, 13);
            this.lblStock.TabIndex = 1;
            this.lblStock.Text = "Stock";
            // 
            // lblLimiteCompra
            // 
            this.lblLimiteCompra.AutoSize = true;
            this.lblLimiteCompra.Location = new System.Drawing.Point(12, 96);
            this.lblLimiteCompra.Name = "lblLimiteCompra";
            this.lblLimiteCompra.Size = new System.Drawing.Size(88, 13);
            this.lblLimiteCompra.TabIndex = 2;
            this.lblLimiteCompra.Text = "Limite de Compra";
            // 
            // lblprecioAntiguo
            // 
            this.lblprecioAntiguo.AutoSize = true;
            this.lblprecioAntiguo.Location = new System.Drawing.Point(12, 133);
            this.lblprecioAntiguo.Name = "lblprecioAntiguo";
            this.lblprecioAntiguo.Size = new System.Drawing.Size(76, 13);
            this.lblprecioAntiguo.TabIndex = 3;
            this.lblprecioAntiguo.Text = "Precio Antiguo";
            // 
            // lblPrecioNuevo
            // 
            this.lblPrecioNuevo.AutoSize = true;
            this.lblPrecioNuevo.Location = new System.Drawing.Point(12, 168);
            this.lblPrecioNuevo.Name = "lblPrecioNuevo";
            this.lblPrecioNuevo.Size = new System.Drawing.Size(72, 13);
            this.lblPrecioNuevo.TabIndex = 4;
            this.lblPrecioNuevo.Text = "Precio Nuevo";
            // 
            // lblIdProveedor
            // 
            this.lblIdProveedor.AutoSize = true;
            this.lblIdProveedor.Location = new System.Drawing.Point(12, 199);
            this.lblIdProveedor.Name = "lblIdProveedor";
            this.lblIdProveedor.Size = new System.Drawing.Size(85, 13);
            this.lblIdProveedor.TabIndex = 5;
            this.lblIdProveedor.Text = "Id del Proveedor";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 233);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Location = new System.Drawing.Point(6, 16);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(65, 13);
            this.lblVencimiento.TabIndex = 7;
            this.lblVencimiento.Text = "Vencimiento";
            // 
            // lblPublicacion
            // 
            this.lblPublicacion.AutoSize = true;
            this.lblPublicacion.Location = new System.Drawing.Point(302, 180);
            this.lblPublicacion.Name = "lblPublicacion";
            this.lblPublicacion.Size = new System.Drawing.Size(62, 13);
            this.lblPublicacion.TabIndex = 8;
            this.lblPublicacion.Text = "Publicación";
            // 
            // groupBoxFechas
            // 
            this.groupBoxFechas.Controls.Add(this.monthCalendar2);
            this.groupBoxFechas.Controls.Add(this.monthCalendar1);
            this.groupBoxFechas.Controls.Add(this.lblVencimiento);
            this.groupBoxFechas.Controls.Add(this.lblPublicacion);
            this.groupBoxFechas.Location = new System.Drawing.Point(335, 27);
            this.groupBoxFechas.Name = "groupBoxFechas";
            this.groupBoxFechas.Size = new System.Drawing.Size(370, 377);
            this.groupBoxFechas.TabIndex = 9;
            this.groupBoxFechas.TabStop = false;
            this.groupBoxFechas.Text = "Fechas";
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(172, 202);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 10;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 31);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 9;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(122, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(175, 20);
            this.txtId.TabIndex = 10;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(122, 58);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(175, 20);
            this.txtStock.TabIndex = 11;
            // 
            // txtLimiteCompra
            // 
            this.txtLimiteCompra.Location = new System.Drawing.Point(122, 93);
            this.txtLimiteCompra.Name = "txtLimiteCompra";
            this.txtLimiteCompra.Size = new System.Drawing.Size(175, 20);
            this.txtLimiteCompra.TabIndex = 12;
            // 
            // txtPrecioAntiguo
            // 
            this.txtPrecioAntiguo.Location = new System.Drawing.Point(122, 126);
            this.txtPrecioAntiguo.Name = "txtPrecioAntiguo";
            this.txtPrecioAntiguo.Size = new System.Drawing.Size(175, 20);
            this.txtPrecioAntiguo.TabIndex = 13;
            // 
            // txtPrecioNuevo
            // 
            this.txtPrecioNuevo.Location = new System.Drawing.Point(122, 161);
            this.txtPrecioNuevo.Name = "txtPrecioNuevo";
            this.txtPrecioNuevo.Size = new System.Drawing.Size(175, 20);
            this.txtPrecioNuevo.TabIndex = 14;
            // 
            // txtIdProv
            // 
            this.txtIdProv.Location = new System.Drawing.Point(122, 196);
            this.txtIdProv.Name = "txtIdProv";
            this.txtIdProv.Size = new System.Drawing.Size(175, 20);
            this.txtIdProv.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(122, 233);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescripcion.Size = new System.Drawing.Size(175, 110);
            this.txtDescripcion.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnCancelar.Location = new System.Drawing.Point(15, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 40);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPublicar
            // 
            this.btnPublicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnPublicar.Location = new System.Drawing.Point(214, 380);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(83, 41);
            this.btnPublicar.TabIndex = 18;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // validator
            // 
            this.validator.ContainerControl = this;
            // 
            // altaOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 441);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtIdProv);
            this.Controls.Add(this.txtPrecioNuevo);
            this.Controls.Add(this.txtPrecioAntiguo);
            this.Controls.Add(this.txtLimiteCompra);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBoxFechas);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblIdProveedor);
            this.Controls.Add(this.lblPrecioNuevo);
            this.Controls.Add(this.lblprecioAntiguo);
            this.Controls.Add(this.lblLimiteCompra);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblId);
            this.Name = "altaOferta";
            this.Text = "Publicar una Oferta";
            this.Controls.SetChildIndex(this.lblId, 0);
            this.Controls.SetChildIndex(this.lblStock, 0);
            this.Controls.SetChildIndex(this.lblLimiteCompra, 0);
            this.Controls.SetChildIndex(this.lblprecioAntiguo, 0);
            this.Controls.SetChildIndex(this.lblPrecioNuevo, 0);
            this.Controls.SetChildIndex(this.lblIdProveedor, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.groupBoxFechas, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.txtStock, 0);
            this.Controls.SetChildIndex(this.txtLimiteCompra, 0);
            this.Controls.SetChildIndex(this.txtPrecioAntiguo, 0);
            this.Controls.SetChildIndex(this.txtPrecioNuevo, 0);
            this.Controls.SetChildIndex(this.txtIdProv, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnPublicar, 0);
            this.Controls.SetChildIndex(this.btnAtras, 0);
            this.groupBoxFechas.ResumeLayout(false);
            this.groupBoxFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.validator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblLimiteCompra;
        private System.Windows.Forms.Label lblprecioAntiguo;
        private System.Windows.Forms.Label lblPrecioNuevo;
        private System.Windows.Forms.Label lblIdProveedor;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Label lblPublicacion;
        private System.Windows.Forms.GroupBox groupBoxFechas;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtLimiteCompra;
        private System.Windows.Forms.TextBox txtPrecioAntiguo;
        private System.Windows.Forms.TextBox txtPrecioNuevo;
        private System.Windows.Forms.TextBox txtIdProv;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.ErrorProvider validator;
    }
}