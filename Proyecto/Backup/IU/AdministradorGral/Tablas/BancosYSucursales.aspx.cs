using System;
using Ext.Net;
using IU.Contabilidad;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class BancosYSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["GestionarBancos_Indice_idindice"] = 0;
            }

            this.ControlAbm1.Tipo = typeof(Entidades.Entity_banco);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_sucursalbanco);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Banco_idbanco", Session["GestionarBancos_Indice_idindice"]),
                new SqlValor("Banco_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
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
                var indx = (Entidades.Entity_banco)row;
                this.ControlAbm2.Valores[0].Valor = indx.Idbanco;
                Session["GestionarBancos_Indice_idindice"] = indx.Idbanco;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}
