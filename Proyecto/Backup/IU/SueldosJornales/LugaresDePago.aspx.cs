using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ModuloSoporte;
using SueldosJornales;
using WebHelper;

namespace IU.SueldosJornales
{
    public partial class LugaresDePago : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(LugaresPago);
            this.ControlAbm1.Titulo = "Gestionar lugares de pago";
            this.ControlAbm1.Descripcion = "Permite administrar los lugares de pago de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }


    }
}
