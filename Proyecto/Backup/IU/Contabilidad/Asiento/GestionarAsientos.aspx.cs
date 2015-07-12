using System;
using WebHelper;
using Entidades;

namespace IU.Contabilidad.Asiento
{
    public partial class GestionarAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entity_asiento);
            this.ControlAbm1.Titulo = "Gestionar asientos";
            this.ControlAbm1.Descripcion = "Permite administrar los asientos manuales de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("GeneradoSistema", false),
                new SqlValor("Ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa), 
                new SqlValor("Tipoasiento_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.ValoresCombo = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Habilitado", true)
            };
            this.ControlAbm1.OnShow();
        }
    }
}
