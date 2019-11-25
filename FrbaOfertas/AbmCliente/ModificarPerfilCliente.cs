﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Entidades;
using System.Data.SqlClient;
using Utilidades;

namespace FrbaOfertas.AbmCliente
{
    public partial class ModificarPerfilCliente : AltaCliente
    {
        public ModificarPerfilCliente()
        {
            InitializeComponent();
        }
        public ModificarPerfilCliente(Cliente cliente,Form v)
        {
            InitializeComponent();
            ventanaAnterior = v;
            inicializarCamposObligatorios();
            cargarCampos(cliente);
            us.setNombreUsuario(cliente.Nombre_usuario);
        }
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtCiudad);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtDireccion);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtTelefono);
        }
        private void cargarCampos(Cliente cliente)
        {
            txtNombre.Text = cliente.Cliente_nombre;
            txtApellido.Text = cliente.Cliente_apellido;
            txtDireccion.Text = cliente.Direccion;
            txtCp.Text = cliente.Cp;
            txtDni.Text = cliente.Dni;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            txtCiudad.Text = cliente.Ciudad;
            txtPiso.Text = cliente.Piso.ToString();
            txtDepto.Text = cliente.Dpto.ToString();
        }

        protected override void btnCrear_Click(object sender, EventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                String query = String.Format("update Clientes set dni=@dni,cliente_nombre=@nom,cliente_apellido=@ap,fecha_nacimiento=@fecha,ciudad=@ciudad,codigo_postal=@cp,telefono=@tel,email=@email,direccion=@direccion,piso=@piso,dpto=@depto where nombre_usuario='{0}'", us.getNombreUsuario());
                SqlCommand cmd = new SqlCommand(query);
                cargarCmd(cmd);
                Utilidades.Utilidades.ejecutar(cmd);
                MessageBox.Show("Cliente actualizado con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventanaAnterior.Show();
                this.Close();
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }
            catch (SqlException error)
            { Utilidades.GestorDeErrores.mostrarErrorSegunTipo(error); }
        }
    }
}
