using System;
using IU.Contabilidad;
using WebHelper;
using Ext.Net;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarIndices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["GestionarIndices_Indice_idindice"] = 0;
            }

            this.ControlAbm1.Tipo = typeof(Entidades.Entity_indice);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_valorindice);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Indice_idindice", Session["GestionarIndices_Indice_idindice"]), // Índice inexistente, dado que no se seleccionó ninguno//
                new SqlValor("Indice_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
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
                var indx = (Entidades.Entity_indice)row;
                this.ControlAbm2.Valores[0].Valor = indx.Idindice;
                Session["GestionarIndices_Indice_idindice"] = indx.Idindice;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}
