﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Utilidades;
using FrbaOfertas.Registro_de_usuario;

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : AltaForm
    {
        private Usuario us;
        public AltaCliente(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
        }
        protected override void inicializarCamposObligatorios(){
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtFechaDeNacimiento);
            camposObligatorios.Add(txtLocalidad);
            camposObligatorios.Add(txtCalle);
            camposObligatorios.Add(txtCp);
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }        

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposObligatoriosCompletados())
            {
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Clientes VALUES (@dni,@nom,@ap,@fecha,@loc,@cp,@tel,@email,@calle,@piso,@depto,@user)", Utilidades.Utilidades.getCon());
                String SelectRol = "Select rol_id from Roles where rol_nombre='Cliente'";
                int rol_id = Convert.ToInt32(Utilidades.Utilidades.ejecutarConsulta(SelectRol).Tables[0].Rows[0]);

                cmd2.Parameters.AddWithValue("@dni", txtDni.Text);
                cmd2.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@ap", txtApellido.Text);
                cmd2.Parameters.AddWithValue("@fecha", txtFechaDeNacimiento.Text);
                cmd2.Parameters.AddWithValue("@loc", txtLocalidad.Text);
                cmd2.Parameters.AddWithValue("@cp", txtCp.Text);
                cmd2.Parameters.AddWithValue("@tel", txtTelefono.Text);
                cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd2.Parameters.AddWithValue("@calle", txtCalle.Text);
                cmd2.Parameters.AddWithValue("@piso", txtPiso.Text);
                cmd2.Parameters.AddWithValue("@depto", txtDepto.Text);
                if (us != null) { cmd2.Parameters.AddWithValue("@user", us.getNombreUsuario()); }

                Utilidades.Utilidades.beginTransaction();
                cargarUsuario(us,rol_id);
                Utilidades.Utilidades.ejecutar(cmd2);
                MessageBox.Show("Cliente guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Utilidades.Utilidades.commit();
            }
        }

    }
}
