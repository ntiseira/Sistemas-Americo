using System;
using WebHelper;

namespace IU.Contabilidad.Asiento
{
    public partial class Movimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_movimiento);
            this.ControlAbm1.Titulo = "Gestionar movimientos";
            this.ControlAbm1.Descripcion = "Permite administrar los movimientos de los asientos.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Asiento_ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEjercicio) ,
                new SqlValor("Asiento_ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Cuenta_plancuentas_codplancuentas", ContabilidadGlobal.Admin.CodPlanCuentas) ,
                new SqlValor("Cuenta_plancuentas_ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEjercicio) ,
                new SqlValor("Cuenta_plancuentas_ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Tipomovimiento_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.ValoresCombo = new SqlValor[]
            {
                new SqlValor("Cuenta_plancuentas_codplancuentas", ContabilidadGlobal.Admin.CodPlanCuentas) ,
                new SqlValor("Plancuentas_ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Plancuentas_ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEmpresa)
            };
            this.ControlAbm1.OnShow();
        }
    }
}
