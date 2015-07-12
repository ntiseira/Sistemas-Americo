using System;
using System.Collections;
using Ext.Net;
using IU.Contabilidad;

namespace IU
{
    public partial class LoginPaso2 : System.Web.UI.Page
    {
        #region Data
        protected Siscont.Contabilidad.AdministradorContabilidad Admin
        {
            get
            {
                return IU.Contabilidad.ContabilidadGlobal.Admin;
            }
        }

        protected long CodEmpresa
        {
            get
            {
                return long.Parse(ComboEmpresas.SelectedItem.Value);
            }
        }

        protected long CodEjercicio
        {
            get
            {
                return long.Parse(ComboEjercicios.SelectedItem.Value);
            }
        }

        protected long CodSucursal
        {
            get
            {
                return long.Parse(ComboSucursales.SelectedItem.Value);
            }
        }

        protected int CodPlan
        {
            get
            {
                return int.Parse(ComboBoxPlanes.SelectedItem.Value);
            }
        }

        protected string CodPuesto
        {
            get
            {
                return (ComboPuestos.SelectedItem.Value);
            }
        }

        #endregion

        #region Refreshing data
        [DirectMethod]
        protected void RefreshPlanesDeCuentas(object sender, DirectEventArgs e)
        {
            try
            {
                IList planes = Admin.ObtenerPlanesDeCuentas(CodEmpresa, CodEjercicio);
                StorePlanes.DataSource = planes;
                StorePlanes.DataBind();
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcionSimple(ex, "Error al intentar actualizar listados");
            }
        }

        protected void RefreshPlanesDeCuentas(object sender, StoreRefreshDataEventArgs e)
        {
            try
            {
                IList planes = Admin.ObtenerPlanesDeCuentas(CodEmpresa, CodEjercicio);
                StorePlanes.DataSource = planes;
                StorePlanes.DataBind();
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcionSimple(ex, "Error al intentar actualizar listados");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!X.IsAjaxRequest)
                {
                    if (ModuloSoporte.Global.CodEmpresa != 0)
                    {
                        Response.Redirect("Principal.aspx");
                    }
                    else if (!ModuloSoporte.Global.Usuario.Equals(""))
                    {
                        this.ObtenerEmpresas();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void ObtenerEmpresas()
        {
            try
            {
                IList empresas = ContabilidadGlobal.Admin.ObtenerListaEmpresas(ModuloSoporte.Global.Usuario);
                StoreEmpresas.DataSource = empresas;
                StoreEmpresas.DataBind();
                if (ComboEmpresas.Items.Count > 0)
                    ComboEmpresas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcion(ex, "Error al intentar obtener empresas");
            }
        }

        [DirectMethod]
        protected void BotonAcceder_Click(object sender, DirectEventArgs e)
        {
            try
            {
                Admin.Acceder(CodEmpresa, CodSucursal, CodEjercicio, CodPuesto, CodPlan);
                ModuloSoporte.Global.CodEmpresa = CodEmpresa;
                ModuloSoporte.Global.CodSucursal = CodSucursal;
                ModuloSoporte.Global.NombreSucursal = ComboSucursales.Text;
                Response.Redirect("Principal.aspx");
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcion(ex, "Error al intentar acceder");
            }
        }
    }
}
