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
using MySql.Data;
using SueldosJornales;
using WebHelper;
using ModuloSoporte;

namespace IU.SueldosJornales
{
    public partial class ObrasSociales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(ObraSocial);
            this.ControlAbm1.Titulo = "Gestionar los Tipos de Obras Sociales";
            this.ControlAbm1.Descripcion = "Permite administrar las distintas Obras Sociales que pueden tener los empleados.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Empresa_idempresa", long.Parse(Global.CodEmpresa.ToString())) };
            this.ControlAbm1.ValoresCombo = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
