using System;

namespace IU.Contabilidad.Asiento
{
    public partial class AsientoAgregado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelCod.Text = Session["cod"].ToString();
            Session["cod"] = "";
        }
    }
}
