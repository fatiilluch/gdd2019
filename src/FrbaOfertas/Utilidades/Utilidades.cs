using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Drawing;

namespace FrbaOfertas.Utilidades
{
    public class Utilidades
    {
        public static DateTime fechaConfig = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["fechaConfig"]);
        public static String condicionesFiltrosTextoExacto(List<TextBox> filtros)
        {
            String condiciones = "";
            if (filtros.Any(box => box.TextLength > 0))
            {
                foreach (TextBox filtro in filtros.Where(box => box.TextLength > 0))
                {
                    condiciones = condiciones + String.Format("{0} " + "= " + "'{1}'" + " and ", filtro.Name, filtro.Text.ToString());
                }

            }
            return condiciones;
        }
        public static String condicionesFiltrosTextoLibre(List<TextBox> filtros)
        {
            String condiciones = "";
            if (filtros.Any(box => box.TextLength > 0))
            {
                foreach (TextBox filtro in filtros.Where(box => box.TextLength > 0))
                {
                    condiciones = condiciones + String.Format("{0} " + "like " + "'{1}'" + " and ", filtro.Name, '%' + filtro.Text.ToString() + '%');
                }

            }
            return condiciones;
        }

        public static String obtenerHash(String texto)
        {
            var passBytes = Encoding.ASCII.GetBytes(texto);
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(passBytes);

            return hash.Aggregate("", (b, next) => next.ToString("x2") + b);
        }

        public static void verificarCampoNumerico(TextBox box)
        {
            int num;
            if (!int.TryParse(box.Text, out num))
            {
                Exception error = new FormatException(String.Format("El campo {0} debe contener solamente numeros",box.Name));
                box.BackColor = Color.LightCoral;
                throw error;
            }
        }
        public static void verificarCampoChar(TextBox box)
        {
            char c;
            if ((box.Text != "") && (!Char.TryParse(box.Text, out c)))//ya que no es un campo obligatorio
            {
                Exception error = new FormatException(String.Format("El campo {0} debe contener solamente un caracter",box.Name));
                box.BackColor = Color.LightCoral;
                throw error;
            }
        }
    }
}
