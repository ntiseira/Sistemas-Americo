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
    public partial class Sueldos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(Sueldo);
            this.ControlAbm1.Titulo = "Gestionar de Sueldos";
            this.ControlAbm1.Descripcion = "Permite administrar los sueldos de los empleados.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("empleados_sucursal_empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.ValoresCombo = new SqlValor[] 
            { 
                new SqlValor("empleados_sucursal_empresa_idempresa", Global.CodEmpresa), 
                new SqlValor("empleados_sucursal_codigoSucursal", Global.CodSucursal) 
            };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
