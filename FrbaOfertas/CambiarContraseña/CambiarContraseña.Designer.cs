namespace FrbaOfertas.CambiarContraseña
{
    partial class CambiarContraseña
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
            this.lblOldP = new System.Windows.Forms.Label();
            this.lblNewP = new System.Windows.Forms.Label();
            this.lblConfirmNewP = new System.Windows.Forms.Label();
            this.txtOldP = new System.Windows.Forms.TextBox();
            this.txtNewP = new System.Windows.Forms.TextBox();
            this.txtConfirmNewP = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOldP
            // 
            this.lblOldP.AutoSize = true;
            this.lblOldP.Location = new System.Drawing.Point(29, 53);
            this.lblOldP.Name = "lblOldP";
            this.lblOldP.Size = new System.Drawing.Size(86, 13);
            this.lblOldP.TabIndex = 0;
            this.lblOldP.Text = "Contraseña vieja";
            // 
            // lblNewP
            // 
            this.lblNewP.AutoSize = true;
            this.lblNewP.Location = new System.Drawing.Point(29, 99);
            this.lblNewP.Name = "lblNewP";
            this.lblNewP.Size = new System.Drawing.Size(96, 13);
            this.lblNewP.TabIndex = 1;
            this.lblNewP.Text = "Nueva Contraseña";
            // 
            // lblConfirmNewP
            // 
            this.lblConfirmNewP.AutoSize = true;
            this.lblConfirmNewP.Location = new System.Drawing.Point(12, 151);
            this.lblConfirmNewP.Name = "lblConfirmNewP";
            this.lblConfirmNewP.Size = new System.Drawing.Size(140, 13);
            this.lblConfirmNewP.TabIndex = 2;
            this.lblConfirmNewP.Text = "Confirmar nueva contraseña";
            // 
            // txtOldP
            // 
            this.txtOldP.Location = new System.Drawing.Point(161, 50);
            this.txtOldP.Name = "txtOldP";
            this.txtOldP.Size = new System.Drawing.Size(100, 20);
            this.txtOldP.TabIndex = 3;
            // 
            // txtNewP
            // 
            this.txtNewP.Location = new System.Drawing.Point(161, 96);
            this.txtNewP.Name = "txtNewP";
            this.txtNewP.Size = new System.Drawing.Size(100, 20);
            this.txtNewP.TabIndex = 4;
            // 
            // txtConfirmNewP
            // 
            this.txtConfirmNewP.Location = new System.Drawing.Point(161, 148);
            this.txtConfirmNewP.Name = "txtConfirmNewP";
            this.txtConfirmNewP.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmNewP.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(94, 206);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtConfirmNewP);
            this.Controls.Add(this.txtNewP);
            this.Controls.Add(this.txtOldP);
            this.Controls.Add(this.lblConfirmNewP);
            this.Controls.Add(this.lblNewP);
            this.Controls.Add(this.lblOldP);
            this.Name = "CambiarContraseña";
            this.Text = "CambiarContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOldP;
        private System.Windows.Forms.Label lblNewP;
        private System.Windows.Forms.Label lblConfirmNewP;
        private System.Windows.Forms.TextBox txtOldP;
        private System.Windows.Forms.TextBox txtNewP;
        private System.Windows.Forms.TextBox txtConfirmNewP;
        private System.Windows.Forms.Button btnConfirmar;
    }
}