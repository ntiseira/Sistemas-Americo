using System;

namespace IU.AdministradorGral.Seguridad
{
    public partial class Permisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Mensaje"] = "Lo sentimos, pero no se ha implementado la funcionalidad para esta versión.";
            Session["Titulo"] = "Funcionalidad no implementada";
            Response.Redirect("../../Mensaje.aspx");
        }
    }
}
