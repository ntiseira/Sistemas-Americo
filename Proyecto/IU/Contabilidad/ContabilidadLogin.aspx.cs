using System;
using Contabilidad;
using ModuloSoporte;

namespace IU.Contabilidad
{
    public partial class ContabilidadLogin : System.Web.UI.Page
    {
        AdministradorContabilidad admin; 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                admin = ContabilidadGlobal.Admin;

                LabelError.Text = "";
                LabelStack.Text = "";

                if (!this.IsPostBack)
                {
                    DropDownEmpresas.DataSource = admin.ObtenerListaEmpresas(Global.Usuario);
                    DropDownEmpresas.DataBind();
                    this.ActualizarListados();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        protected void BotonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                admin.Acceder(CodEmpresa, CodEjercicio, CodPuestoTrabajo);
                Response.Redirect("ContabilidadPrincipal.aspx");
            }
            catch(Exception ex)
            {
                this.ShowException(ex);
            }
        }

        protected void DropDownEjercicios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarListados();
        }

        /// <summary>
        /// Actualiza la lista de ejercicios y puestos.
        /// </summary>
        private void ActualizarListados()
        {
            try
            {
                DropDownEjercicios.DataSource = admin.ObtenerEjercicios(this.CodEmpresa);
                DropDownEjercicios.DataBind();
                DropDownPuestos.DataSource = admin.ObtenerPuestosDeTrabajo(this.CodEmpresa);
                DropDownPuestos.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private long CodEmpresa
        {
            get
            {
                string item = DropDownEmpresas.SelectedValue;
                return long.Parse(item.Substring(0, item.IndexOf(" ")));
            }
        }

        //private string CodEjercicio
        private long CodEjercicio
        {
            get
            {
                string item = DropDownEjercicios.SelectedValue;
                return long.Parse(item.Substring(0, item.IndexOf(" ")));
                //return item;
            }
        }

        private string CodPuestoTrabajo
        {
            get
            {
                string item = DropDownPuestos.SelectedValue;
                return item;
                //return long.Parse(item.Substring(0, item.IndexOf(" ")));
            }
        }

        public void ShowException(Exception ex)
        {
            LabelError.Text = ex.Message;
            LabelStack.Text = ex.StackTrace;
        }
    }
}
