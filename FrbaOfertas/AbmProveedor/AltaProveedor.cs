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
using Utilidades;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : AltaForm
    {
        private Usuario us;
        public  AltaProveedor(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
        }
        
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtRs);
            camposObligatorios.Add(txtCuit);
            camposObligatorios.Add(txtRubro);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtTelefono);
            camposObligatorios.Add(txtLocalidad);
            camposObligatorios.Add(txtCalle);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtContacto);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
             try
             {
                 Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);

                 SqlCommand cmd2 = new SqlCommand("INSERT INTO Proveedores VALUES (@rs,@email,@telefono,@ciudad,@cuit,@rubro_id,@prov_nom,@calle,@piso,@depto,@user)", Utilidades.Utilidades.getCon());
                 String SelectRol = "Select rol_id from Roles where rol_nombre='Proveedor'";
                 int rol_id = Convert.ToInt32(Utilidades.Utilidades.ejecutarConsulta(SelectRol).Tables[0].Rows[0]);

                 cmd2.Parameters.AddWithValue("@rs", txtRs.Text);
                 cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
                 cmd2.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                 cmd2.Parameters.AddWithValue("@ciudad", txtLocalidad.Text);
                 cmd2.Parameters.AddWithValue("@cuit", txtCuit.Text);
                 cmd2.Parameters.AddWithValue("@rubro_id", txtRubro.Text);
                 cmd2.Parameters.AddWithValue("@prov_nom", txtContacto.Text);
                 cmd2.Parameters.AddWithValue("@calle", txtCalle.Text);
                 cmd2.Parameters.AddWithValue("@piso", txtPiso.Text);
                 cmd2.Parameters.AddWithValue("@depto", txtDepto.Text);
                 if (us != null) { cmd2.Parameters.AddWithValue("@user", us.getNombreUsuario()); }

                 Utilidades.Utilidades.beginTransaction();
                 cargarUsuario(us,rol_id);
                 Utilidades.Utilidades.ejecutar(cmd2);
                 Utilidades.Utilidades.commit();
                 MessageBox.Show("Proveedor guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(CamposObligatoriosIncompletosException error)
                {
                    error.mensaje();
                }
                catch (SqlException error)
                {
                    Utilidades.GestorDeErrores.mostrarErrorSegunTipo(error);
                }
            }
        }
    }

