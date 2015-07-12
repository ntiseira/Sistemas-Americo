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
using SueldosJornales;
using WebHelper;
using ModuloSoporte;

namespace IU.SueldosJornales
{
    public partial class ObrasSocialesEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(ObraSocialEmpleado);
            this.ControlAbm1.Titulo = "Gestionar Datos de la Obra Social de un empleado en particular";
            this.ControlAbm1.Descripcion = "Permite administrar las obras sociales de los empleados de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("TiposObrasSociales_empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.ValoresCombo = new SqlValor[] { new SqlValor("TiposObrasSociales_empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
