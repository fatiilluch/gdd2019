namespace FrbaOfertas.ListadoEstadistico
{
    partial class Listado_Estadistico
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
            this.comboBoxSemestre = new System.Windows.Forms.ComboBox();
            this.lblSemestral = new System.Windows.Forms.Label();
            this.lblTipoListado = new System.Windows.Forms.Label();
            this.comboBoxTipoListado = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dataGridListado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSemestre
            // 
            this.comboBoxSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemestre.Items.AddRange(new object[] {
            "1",
            "2",
            "Descuentos",
            "Facturación"});
            this.comboBoxSemestre.Location = new System.Drawing.Point(134, 30);
            this.comboBoxSemestre.Name = "comboBoxSemestre";
            this.comboBoxSemestre.Size = new System.Drawing.Size(184, 21);
            this.comboBoxSemestre.TabIndex = 3;
            // 
            // lblSemestral
            // 
            this.lblSemestral.AutoSize = true;
            this.lblSemestral.Location = new System.Drawing.Point(42, 30);
            this.lblSemestral.Name = "lblSemestral";
            this.lblSemestral.Size = new System.Drawing.Size(51, 13);
            this.lblSemestral.TabIndex = 1;
            this.lblSemestral.Text = "Semestre";
            // 
            // lblTipoListado
            // 
            this.lblTipoListado.AutoSize = true;
            this.lblTipoListado.Location = new System.Drawing.Point(42, 75);
            this.lblTipoListado.Name = "lblTipoListado";
            this.lblTipoListado.Size = new System.Drawing.Size(80, 13);
            this.lblTipoListado.TabIndex = 2;
            this.lblTipoListado.Text = "Tipo de Listado";
            // 
            // comboBoxTipoListado
            // 
            this.comboBoxTipoListado.FormattingEnabled = true;
            this.comboBoxTipoListado.Location = new System.Drawing.Point(134, 72);
            this.comboBoxTipoListado.Name = "comboBoxTipoListado";
            this.comboBoxTipoListado.Size = new System.Drawing.Size(184, 21);
            this.comboBoxTipoListado.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnConsultar.Location = new System.Drawing.Point(134, 114);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(98, 36);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // dataGridListado
            // 
            this.dataGridListado.AllowUserToAddRows = false;
            this.dataGridListado.AllowUserToDeleteRows = false;
            this.dataGridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridListado.Location = new System.Drawing.Point(12, 165);
            this.dataGridListado.Name = "dataGridListado";
            this.dataGridListado.ReadOnly = true;
            this.dataGridListado.Size = new System.Drawing.Size(342, 153);
            this.dataGridListado.TabIndex = 7;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 330);
            this.Controls.Add(this.dataGridListado);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.comboBoxTipoListado);
            this.Controls.Add(this.comboBoxSemestre);
            this.Controls.Add(this.lblTipoListado);
            this.Controls.Add(this.lblSemestral);
            this.Name = "Listado_Estadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSemestral;
        private System.Windows.Forms.Label lblTipoListado;
        private System.Windows.Forms.ComboBox comboBoxSemestre;
        private System.Windows.Forms.ComboBox comboBoxTipoListado;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dataGridListado;
    }
}