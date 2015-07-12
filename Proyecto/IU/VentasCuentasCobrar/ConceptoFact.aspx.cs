using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebHelper;
using ModuloSoporte;

namespace IU.VentasCuentasCobrar
{
    public partial class ConceptoFact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_concepto);
                this.ControlAbm1.Titulo = "Gestionar Conceptos de facturación";
                this.ControlAbm1.Descripcion = "Permite administrar todos los conceptos de facturación.";
                this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
                this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}