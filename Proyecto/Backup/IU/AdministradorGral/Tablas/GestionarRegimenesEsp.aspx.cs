using System;
using IU.Contabilidad;
using WebHelper;
using ModuloSoporte;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarRegimenesEsp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_regimenesEspeciales);
            this.ControlAbm1.Titulo = "Gestionar los regimenes especiales";
            this.ControlAbm1.Descripcion = "Permite administrar los regimenes especiales de facturación.";
            this.ControlAbm1.ValoresCombo = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm1.OnShow();
        }
    }
}
