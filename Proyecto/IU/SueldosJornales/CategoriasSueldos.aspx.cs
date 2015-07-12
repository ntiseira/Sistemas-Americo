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
using SueldosJornales;

namespace IU.SueldosJornales
{
    public partial class CategoriasSueldos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(CategoriaSueldo);
            this.ControlAbm1.Titulo = "Gestionar Categorías de Sueldos";
            this.ControlAbm1.Descripcion = "Permite administrar las Categorías de los sueldos de los empleados.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Empresa_idempresa", long.Parse(Global.CodEmpresa.ToString())) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
