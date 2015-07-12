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

namespace IU.AdministradorGral.Tablas
{
    public partial class RegimenesEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm.Tipo = typeof(Entidades.Entity_regimenesEspeciales);
            this.ControlAbm.Titulo = "Gestionar los regimenes especiales";
            this.ControlAbm.Descripcion = "Permite administrar los regimenes especiales de facturación.";
            this.ControlAbm.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm.OnShow();
        }
    }
}
