using System;
using WebHelper;
using Ext.Net;

namespace IU.Contabilidad.PlanCuentas
{
    public partial class Gestionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["PlanCuentas_Id"] = 0;
            }

            /*this.ControlAbm1.Tipo = typeof(Entidades.Entity_planCuentas);
            this.ControlAbm1.Titulo = "Gestionar planes de cuentas";
            this.ControlAbm1.Descripcion = "Permite administrar los planes de cuentas de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEjercicio) ,
                new SqlValor("Ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_jerarquia);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Plancuentas_codplancuentas", Session["PlanCuentas_Id"]), // Índice inexistente, dado que no se seleccionó ninguno//
                new SqlValor("Plancuentas_ejercicio_codejercicio", ContabilidadGlobal.Admin.CodEjercicio),
                new SqlValor("Plancuentas_ejercicio_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
            };
            this.ControlAbm2.OnShow();*/
        }

        void ControlAbm1_AlSeleccionar(object sender, EventArgs e)
        {
            object row = this.ControlAbm1.SelectedItem;

            if (row == null)
            {
                this.ControlAbm2.Valores[0].Valor = 0;
            }
            else
            {
                var indx = (Entidades.Entity_planCuentas)row;
                this.ControlAbm2.Valores[0].Valor = indx.Codplancuentas;
                Session["PlanCuentas_Id"] = indx.Codplancuentas;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}
