using System;
using Ext.Net;
using ModuloSoporte;

namespace IU
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Global.CodEmpresa != 0)
            //{
            //    Response.Redirect("Principal.aspx");
            //}
        }

        [DirectMethod]
        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {
            this.Window1.Hide();

            try
            {
                if (ModuloSoporte.AdministradoraUsuarios.Acceder(this.txtUsername.Text, this.txtPassword.Text))
                {
                    Response.Redirect("LoginPaso2.aspx");
                }
                else
                {
                    IU.UIHelper.MostrarError(
                        "No se ha podido iniciar sesión. Usuario o contraseña incorrecta.",
                    "Error", new JFunction { Fn = "actualizar" });
                }
            }
            catch (Exception)
            {
                IU.UIHelper.MostrarError("No se ha podido establecer conexión con las bases de datos. Por favor, verifique el estado de su conexión a internet o pongase en contacto con el área de soporte técnico.",
                    "Error", new JFunction { Fn = "actualizar" });
            }
        }

        [DirectMethod]
        protected void btnCancel_Click(object sender, DirectEventArgs e)
        {
            this.Window1.Hide();
            Response.Redirect("Presentacion.aspx");
        }
    }
}
