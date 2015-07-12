using System;
using System.Web.UI.WebControls;

namespace IU.Contabilidad
{
    public partial class ContabilidadPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelError.Text = "";
            LabelStack.Text = "";
        }

        protected void MenuContabilidad_MenuItemClick(object sender, MenuEventArgs e)
        {
            try
            {
                switch (MenuContabilidad.SelectedValue.ToLower())
                {
                    #region Asientos
                    #endregion

                    #region Tipos de asientos
                    case "listar tipos de asientos":
                        {
                            //ListarTiposAsientos1.OnShow();
                            MultiView1.SetActiveView(ViewListar);
                            ControlListar1.DataSource = ContabilidadGlobal.Admin.ObtenerListaTiposAsientos();
                            ControlListar1.OnShow();
                        }
                        break;
                    #endregion                    

                    #region Centros de costo
                    case "listar centros de costo":
                        {
                            MultiView1.SetActiveView(ViewListar);
                            ControlListar1.DataSource = ContabilidadGlobal.Admin.ObtenerListaCentrosDeCosto();
                            ControlListar1.OnShow();
                        }
                        break;
                    #endregion

                    #region Áreas
                    case "listar areas":
                        {
                            MultiView1.SetActiveView(ViewListar);
                            ControlListar1.DataSource = ContabilidadGlobal.Admin.ObtenerListaAreas();
                            ControlListar1.OnShow();
                        }
                        break;
                    #endregion

                    #region Departamentos
                    case "listar departamentos":
                        {
                            MultiView1.SetActiveView(ViewListar);
                            ControlListar1.DataSource = ContabilidadGlobal.Admin.ObtenerListaDepartamentos();
                            ControlListar1.OnShow();
                        }
                        break;
                    #endregion

                    #region Tipos de movimientos
                    case "listar tipos de movimientos":
                        {
                            //ListarTiposAsientos1.OnShow();
                            MultiView1.SetActiveView(ViewListar);
                            ControlListar1.DataSource = ContabilidadGlobal.Admin.ObtenerListaTiposMovimientos();
                            ControlListar1.OnShow();
                        }
                        break;
                    #endregion

                    #region Unidades

                    #endregion

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        public void ShowException(Exception ex)
        {
            LabelError.Text = ex.Message;
            LabelStack.Text = ex.StackTrace;
        }
    }
}
