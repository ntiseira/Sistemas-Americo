using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class ConceptoNoGravadoEnIva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_conceptonoiva);
            this.ControlAbm1.Titulo = "Gestionar conceptos no gravados en IVA";
            this.ControlAbm1.Descripcion = "Permite definir los diferentes conceptos no gravados que se pueden incluir en las operaciones (p. ej. los impuestos internos).";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.OnShow();
        }
    }
}
