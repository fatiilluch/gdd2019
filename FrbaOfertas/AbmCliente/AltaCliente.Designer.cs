namespace FrbaOfertas.AbmCliente
{
    partial class AltaCliente
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
            this.btnCrearCliente = new System.Windows.Forms.Button();
            this.txtFechaDeNacimiento = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblCp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrearCliente
            // 
            this.btnCrearCliente.Location = new System.Drawing.Point(257, 312);
            this.btnCrearCliente.Name = "btnCrearCliente";
            this.btnCrearCliente.Size = new System.Drawing.Size(92, 32);
            this.btnCrearCliente.TabIndex = 0;
            this.btnCrearCliente.Text = "Crear";
            this.btnCrearCliente.UseVisualStyleBackColor = true;
            this.btnCrearCliente.Click += new System.EventHandler(this.btnCrearCliente_Click);
            // 
            // txtFechaDeNacimiento
            // 
            this.txtFechaDeNacimiento.Location = new System.Drawing.Point(355, 124);
            this.txtFechaDeNacimiento.Name = "txtFechaDeNacimiento";
            this.txtFechaDeNacimiento.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDeNacimiento.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(355, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(87, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(87, 93);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(355, 202);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(100, 20);
            this.txtCp.TabIndex = 5;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(87, 202);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(355, 60);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(87, 124);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(40, 63);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(40, 96);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 10;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(61, 127);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 11;
            this.lblDni.Text = "Dni:";
            this.lblDni.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(240, 127);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(109, 13);
            this.lblFechaNacimiento.TabIndex = 12;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento:";
            this.lblFechaNacimiento.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(297, 96);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(311, 60);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(38, 13);
            this.lblMail.TabIndex = 14;
            this.lblMail.Text = "E-mail:";
            // 
            // lblCp
            // 
            this.lblCp.AutoSize = true;
            this.lblCp.Location = new System.Drawing.Point(274, 202);
            this.lblCp.Name = "lblCp";
            this.lblCp.Size = new System.Drawing.Size(75, 13);
            this.lblCp.TabIndex = 15;
            this.lblCp.Text = "Codigo Postal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Direccion";
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(46, 237);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(30, 13);
            this.lblPiso.TabIndex = 17;
            this.lblPiso.Text = "Piso:";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(37, 269);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(39, 13);
            this.lblDepto.TabIndex = 18;
            this.lblDepto.Text = "Depto:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(46, 205);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 19;
            this.lblCalle.Text = "Calle:";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(87, 234);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 20;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(87, 266);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 21;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(355, 237);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 22;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(293, 241);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 23;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 356);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblDepto);
            this.Controls.Add(this.lblPiso);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCp);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtCp);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtFechaDeNacimiento);
            this.Controls.Add(this.btnCrearCliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaCliente";
            this.Text = "Registro del cliente";
            this.Load += new System.EventHandler(this.AltaCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearCliente;
        private System.Windows.Forms.TextBox txtFechaDeNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblCp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
    }
}