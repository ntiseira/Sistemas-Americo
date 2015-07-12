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
using WebHelper;
using AdministradorGeneral.Empresas;

namespace IU.VentasCuentasCobrar
{
    public partial class TipoConceptos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm.Tipo = typeof(Entidades.Entity_tipoconcepto);
                this.ControlAbm.Titulo = "Gestionar tipos de conceptos";
                this.ControlAbm.Descripcion = "Permite administrar los tipos de conceptos.";
                this.ControlAbm.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ModuloSoporte.Global.CodEmpresa) 
                };
                this.ControlAbm.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
