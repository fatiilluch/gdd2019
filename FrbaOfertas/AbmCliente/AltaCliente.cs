using System;
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
using FrbaOfertas.Entidades;

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
            txtUsuario.Text = us.getNombreUsuario();
            txtUsuario.Enabled = false;
            txtUsuario.BackColor = Color.DarkGray;
        }
        public AltaCliente(Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
        }
        public AltaCliente(Cliente cl, Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            cargarCampos(cl);
            txtUsuario.Text = cl.Nombre_usuario;
            txtUsuario.Enabled = false;
            txtUsuario.BackColor = Color.DarkGray;

        }
        protected override void inicializarCamposObligatorios(){
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtLocalidad);
            camposObligatorios.Add(txtCalle);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtUsuario);
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }        

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposObligatoriosCompletados())
            {
                try{
                        Utilidades.GestorDeErrores.verificarClientesDuplicados(txtDni.Text.ToString());
                        Utilidades.GestorDeErrores.verificarUsuarioPorRolExistente(RepoRol.getInstance().buscarRol("Cliente").Id,txtUsuario.Text.ToString());

                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Clientes VALUES (@dni,@nom,@ap,@fecha,@loc,@cp,@tel,@email,@calle,@piso,@depto,@user)", Utilidades.Utilidades.getCon());
                        String SelectRol = "Select rol_id from Roles where rol_nombre='Cliente'";
                        int rol_id = Convert.ToInt32(Utilidades.Utilidades.ejecutarConsulta(SelectRol).Tables[0].Rows[0]["rol_id"]);

                        cmd2.Parameters.AddWithValue("@dni", txtDni.Text);
                        cmd2.Parameters.AddWithValue("@nom", txtNombre.Text);
                        cmd2.Parameters.AddWithValue("@ap", txtApellido.Text);
                        cmd2.Parameters.AddWithValue("@fecha", fechaNacimiento.Value);
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
                        Utilidades.Utilidades.commit();                        
                        MessageBox.Show("Cliente guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ventanaAnterior.Show();
                        this.Close();
                        

                }
                catch(Utilidades.ClienteDuplicadoException c)
                {
                    c.mensaje();
                }
                catch(Utilidades.UsuarioConRolExistenteException c)
                {
                    c.mensaje();
                }

                
            }
        }

        private void AltaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventanaAnterior.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            camposObligatorios.ForEach(box => box.Clear());
            txtPiso.Clear();
            txtDepto.Clear();
        }
        private void cargarCampos(Cliente cliente)
        {
            txtNombre.Text = cliente.Cliente_nombre;
            txtApellido.Text = cliente.Cliente_apellido;
            txtCalle.Text = cliente.Direccion;
            txtCp.Text = cliente.Cp;
            txtDni.Text = cliente.Dni;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            txtLocalidad.Text = cliente.Ciudad;
            txtPiso.Text = cliente.Piso.ToString();
            txtDepto.Text = cliente.Dpto.ToString();

        }

    }
}
