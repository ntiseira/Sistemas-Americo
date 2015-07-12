using System;
using ModuloSoporte;
using SueldosJornales;
using WebHelper;

namespace IU.SueldosJornales
{
    public partial class TiposDeConceptos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(TipoConcepto);
            this.ControlAbm1.Titulo = "Gestionar Tipo de Concepto";
            this.ControlAbm1.Descripcion = "Permite administrar los tipos de conceptos que se les otorgarán a los empleados en el sueldo.";
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
