namespace FrbaOfertas.LoginYSeguridad
{
    partial class Login
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
            this.txtUsserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.gD2C2019DataSet = new FrbaOfertas.GD2C2019DataSet();
            this.gD2C2019DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsserName
            // 
            this.txtUsserName.Location = new System.Drawing.Point(112, 82);
            this.txtUsserName.Name = "txtUsserName";
            this.txtUsserName.Size = new System.Drawing.Size(100, 20);
            this.txtUsserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(112, 169);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblUsserName
            // 
            this.lblUsserName.AutoSize = true;
            this.lblUsserName.Location = new System.Drawing.Point(12, 85);
            this.lblUsserName.Name = "lblUsserName";
            this.lblUsserName.Size = new System.Drawing.Size(96, 13);
            this.lblUsserName.TabIndex = 2;
            this.lblUsserName.Text = "Nombre de usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(45, 172);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(109, 35);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(60, 13);
            this.lblBienvenido.TabIndex = 4;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(94, 217);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // gD2C2019DataSet
            // 
            this.gD2C2019DataSet.DataSetName = "GD2C2019DataSet";
            this.gD2C2019DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gD2C2019DataSetBindingSource
            // 
            this.gD2C2019DataSetBindingSource.DataSource = this.gD2C2019DataSet;
            this.gD2C2019DataSetBindingSource.Position = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsserName);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.BindingSource gD2C2019DataSetBindingSource;
        private GD2C2019DataSet gD2C2019DataSet;
    }
}