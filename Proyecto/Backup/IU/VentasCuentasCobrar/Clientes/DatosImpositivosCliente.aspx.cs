using System;
using Ext.Net;
using VentasCuentasCobrar;
using WebHelper;
using IU.Contabilidad;

namespace IU.VentasCuentasCobrar.Clientes
{
    public partial class DatosImpositivosCliente : System.Web.UI.Page
    {
        private const string var = "DatosImpositivosCliente.Cliente";
        private const string oldvar = "DatosImpositivosCliente.Cliente.Old";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[var] == null || Session[var].ToString().Equals(""))
                {
                    if (!X.IsAjaxRequest)
                    {
                        SeleccionarCliente.Preparar(var, "DatosImpositivosCliente.aspx", this);
                        Response.Redirect("SeleccionarCliente.aspx");
                    }
                    else
                    {
                        Session[var] = Session[oldvar];
                    }
                }

                var codCliente = (int)Session[var];
                AdministradorVentas.CrearDatosSiNoExisten(codCliente);
               
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_clientedatosimpositivos);
                this.ControlAbm1.Titulo = "Datos impositivos";
                this.ControlAbm1.MostrarFiltros = false;
                this.ControlAbm1.Descripcion = "Trabaje sobre la fila mostrada.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Cliente_codcliente", codCliente) ,
                    new SqlValor("Cliente_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
             this.ControlAbm1.Permisos = AdministradorGeneral.Seguridad.Permisos.PermisosGuest;
         this.ControlAbm1.Permisos.Modif = true;
                this.ControlAbm1.OnShow();

                Session[oldvar] = Session[var];
                Session[var] = null;
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
