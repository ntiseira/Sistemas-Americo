using System;
using Ext.Net;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class ConsultarMonedas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["GestionarMonedas_Indice_idindice"] = 0;
            }

            this.ControlAbm1.Tipo = typeof(Entidades.Entity_moneda);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_cambiomoneda);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Moneda_idmoneda", Session["GestionarMonedas_Indice_idindice"])
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
                var indx = (Entidades.Entity_moneda)row;
                this.ControlAbm2.Valores[0].Valor = indx.Idmoneda;
                Session["GestionarMonedas_Indice_idindice"] = indx.Idmoneda;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}
