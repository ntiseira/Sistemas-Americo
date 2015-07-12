using System;
using WebHelper;

namespace IU.Contabilidad.Cuentas
{
    public partial class Gestionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_cuenta);
            this.ControlAbm1.Titulo = "Gestionar cuentas";
            this.ControlAbm1.Descripcion = "Permite administrar las cuentas de un determinado plan de cuentas.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Plancuentas_ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEjercicio) ,
                new SqlValor("Plancuentas_ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.ValoresCombo = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.OnShow();
        }
    }
}
