using System;
using WebHelper;

namespace IU.Contabilidad.CentrosCosto
{
    public partial class Gestionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_centrocostos);
                this.ControlAbm1.Titulo = "Gestionar centros de costo";
                this.ControlAbm1.Descripcion = "Permite administrar los centros de costo de la empresa.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
                this.ControlAbm1.ValoresCombo = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                    new SqlValor("Habilitado", true) 
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
