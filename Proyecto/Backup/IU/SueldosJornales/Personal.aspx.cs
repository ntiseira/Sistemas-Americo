using System;
using ModuloSoporte;
using SueldosJornales.Empleados;
using WebHelper;

namespace IU.SueldosJornales
{
    public partial class Personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(Empleado);
            this.ControlAbm1.Titulo = "Gestionar Empleados";
            this.ControlAbm1.Descripcion = "Permite administrar todos los empleados de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Sucursal_empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.ValoresCombo = new SqlValor[] { new SqlValor("Sucursal_empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
