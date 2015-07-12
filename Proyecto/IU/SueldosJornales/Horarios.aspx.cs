using System;
using ModuloSoporte;
using WebHelper;
using SueldosJornales;

namespace IU.SueldosJornales
{
    public partial class Horarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            this.ControlAbm1.Tipo = typeof(Horario);
            this.ControlAbm1.Titulo = "Gestionar Horarios de empleados";
            this.ControlAbm1.Descripcion = "Permite administrar los horarios de los empleados.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empleados_sucursal_codigoSucursal", Global.CodEmpresa),
                new SqlValor("empleados_sucursal_empresa_idempresa", Global.CodSucursal)
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
