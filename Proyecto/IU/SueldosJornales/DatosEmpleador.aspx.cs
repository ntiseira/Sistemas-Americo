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
using WebHelper;
using ModuloSoporte;
using AdministradorGeneral;

namespace IU.SueldosJornales
{
    public partial class DatosEmpleador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(Empresa);
            this.ControlAbm1.Titulo = "Gestionar Datos de la Empresa";
            this.ControlAbm1.Descripcion = "Permite administrar los datos de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("idEmpresa", long.Parse(Global.CodEmpresa.ToString())) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
