using System;
using System.IO;
using System.Net;
using Ext.Net;
using IU.Contabilidad;
using ModuloSoporte;
using Siscont.AdministradorGeneral.Tablas;

namespace IU
{
    public partial class NuevaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Contabilidad.ContabilidadGlobal.Admin.Logueado)
            {
#if DEBUG
                Global.CodEmpresa = 1;
                Global.CodSucursal = 1;
                Global.Usuario = "prueba";
                Global.TipoUsuario = "Administrador";
                Global.NombreEmpresa = "La serenisima";
                Contabilidad.ContabilidadGlobal.Admin.CodEmpresa = 1;
                Contabilidad.ContabilidadGlobal.Admin.CodEjercicio = 1;
                Contabilidad.ContabilidadGlobal.Admin.CodPuesto = "puesto1";
                Contabilidad.ContabilidadGlobal.Admin.Permisos = AdministradorGeneral.Seguridad.Permisos.PermisosAdmin;
#else
                Response.Redirect("Default.aspx");
#endif
            }
         
            //Cargo Tab Bienvenida
            TabPanel1.AddScript("addTab(#{TabPanel1}, 'Inicio', 'Inicio.aspx');");

            //CARGA DE DATOS MENÚ DERECHO
            LabelEmpresa.Text = "Empresa: " + Global.NombreEmpresa;
            LabelSucursal.Text = "Sucursal: " + Global.CodSucursal;
            LabelUsuario.Text = "Usuario: " + Global.Usuario;
            LabelPermisos.Text = "Permisos: " + Global.TipoUsuario;

            if (!X.IsAjaxRequest)
            {
                AdministradorGeneral.Administrador.ActualizarCotizaciones();
                MostrarCotizaciones();
            }

#if DEBUG
            MenuItemGestionarCuentas.Visible = true;
            MenuItemIngresoComprobantes.Visible = true;
            if (!X.IsAjaxRequest)
                panelSuperior.Title += " DEBUG MODE";
#endif
        }

        private void MostrarCotizaciones()
        {
            try
            {
                MenuPanelCotizacion.Show();

                var cambio = AdministradorGeneral.Administrador.GetUltimoCambio(Moneda.Dolar);
                DolarFecha.Text = cambio.Fechacambio.ToShortDateString();
                DolarHora.Text = cambio.Fechacambio.ToShortTimeString();
                DolarCompra.Text = string.Format(Traductor.TraductorHelper.Culture, "{0:n} pesos (arg)", cambio.Compra);
                DolarVenta.Text = string.Format(Traductor.TraductorHelper.Culture, "{0:n} pesos (arg)", cambio.Venta);

                cambio = AdministradorGeneral.Administrador.GetUltimoCambio(Moneda.Euro);
                EuroFecha.Text = cambio.Fechacambio.ToShortDateString();
                EuroHora.Text = cambio.Fechacambio.ToShortTimeString();
                EuroCompra.Text = string.Format(Traductor.TraductorHelper.Culture, "{0:n} pesos (arg)", cambio.Compra);
                EuroVenta.Text = string.Format(Traductor.TraductorHelper.Culture, "{0:n} pesos (arg)", cambio.Venta);
            }
            catch
            {
                OcultarCotizaciones();
            }
        }

        private void OcultarCotizaciones()
        {
            MenuPanelCotizacion.Hide();
            MenuSeparatorCot.Hide();
        }

        [DirectMethod]
        protected void MenuItemTab_Click(object sender, DirectEventArgs e)
        {
            Session["Evento"] = e.ExtraParams["Evento"];
            object panel = Session["TPanel"];
            object tab = Session["TTab"];
            object menu = Session["TMenu"];

        }

        [DirectMethod]
        protected void Actuar(object tab, object menu)
        {
            Session["TTab"] = tab;
            Session["TMenu"] = menu;
        }

        [DirectMethod]
        protected void CerrarSesion_Click(object sender, DirectEventArgs e)
        {
            ContabilidadGlobal.Admin.CerrarSesion();
            Global.CerrarSesion();
            Response.Redirect("Default.aspx");
        }
    }
}
