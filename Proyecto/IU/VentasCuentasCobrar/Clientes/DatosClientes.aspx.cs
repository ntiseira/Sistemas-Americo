using System;
using AdministradorGeneral.Seguridad;
using Ext.Net;
using IU.Contabilidad;
using VentasCuentasCobrar;
using WebHelper;

namespace IU.VentasCuentasCobrar.Clientes
{
    public partial class DatosClientes : System.Web.UI.Page
    {
        private const string var = "OtrosDatos.Cliente";
        private const string oldvar = "OtrosDatos.Cliente.Old";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[var] == null || Session[var].ToString().Equals(""))
                {
                    if (!X.IsAjaxRequest)
                    {
                        SeleccionarCliente.Preparar(var, "DatosClientes.aspx", this);
                        Response.Redirect("SeleccionarCliente.aspx");
                        return;
                    }
                    else
                    {
                        Session[var] = Session[oldvar];
                    }
                }

                var codCliente = (int)Session[var];
                AdministradorVentas.CrearDatosSiNoExisten(codCliente);

                this.ControlAbm1.Tipo = typeof(Entidades.Entity_clienteotrosdatos);
                this.ControlAbm1.Titulo = "Otros datos";
                this.ControlAbm1.MostrarFiltros = false;
                this.ControlAbm1.Descripcion = "Trabaje sobre la fila mostrada.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Cliente_codcliente", codCliente) ,
                    new SqlValor("Cliente_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
                this.ControlAbm1.Permisos = Permisos.PermisosGuest;
                this.ControlAbm1.Permisos.Alta = true;
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
