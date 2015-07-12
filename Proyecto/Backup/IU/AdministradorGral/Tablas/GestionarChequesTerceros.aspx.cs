using System;
using AdministradorGeneral.Tablas;
using WebHelper;
using IU.Contabilidad;
using Ext.Net;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarChequesTerceros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["GestionarTerceros_Indice_idindice"] = 0;
            }

            this.ControlAbm1.Tipo = typeof(Entidades.Entity_cheque);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Banco_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("Origen", 1)
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_chequedeterceros);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Cheque_idcheque", Session["GestionarTerceros_Indice_idindice"]),
                new SqlValor("Cheque_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
            };

            this.ControlAbm2.OnShow();
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
                var indx = (Entidades.Entity_cheque)row;
                this.ControlAbm2.Valores[0].Valor = indx.Idcheque;
                Session["GestionarTerceros_Indice_idindice"] = indx.Idcheque;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}
