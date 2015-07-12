using System;

namespace IU.PanelDeControl.GenReportes.General
{
    public partial class UsuariosDeSucursales1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuariosDeSucursales uds = new UsuariosDeSucursales();
            CrystalReportViewer1.ReportSource = uds;
            this.CrystalReportViewer1.DataBind();
        }
    }
}
