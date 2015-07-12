using System;
using Ext.Net;
using System.Collections.Generic;

namespace IU.Contabilidad.Libro
{
    public partial class PrepararLibroDiario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!X.IsAjaxRequest)
                {
                    ComboBox1.Items.Clear();

                    foreach (object o in ContabilidadGlobal.Admin.ObtenerDescripTiposAsientos())
                    {
                        ComboBox1.Items.Add(new Ext.Net.ListItem(o.ToString(), o.ToString()));
                    }

                    CheckboxTodos.Checked = true;
                    ComboBox1.Hide();

                    DateFieldDesde.SelectedDate =
                    DateFieldDesde.MinDate =
                    DateFieldHasta.MinDate = ContabilidadGlobal.Admin.ObtenerInicioEjercicio();
                    DateFieldHasta.SelectedDate =
                    DateFieldDesde.MaxDate =
                    DateFieldHasta.MaxDate = ContabilidadGlobal.Admin.ObtenerFinEjercicio();
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, 
                    "Error al intentar preparar el libro diario.");
            }
        }

        [DirectMethod]
        protected void Checkbox_Check(object sender, DirectEventArgs e)
        {
            if (!CheckboxTodos.Checked)
                ComboBox1.Show();
            else
                ComboBox1.Hide();
        }

        [DirectMethod]
        protected void BotonConsultar_OnClick(object sender, DirectEventArgs e)
        {
            try
            {
                if (CheckboxTodos.Checked == false)
                {
                    List<string> tipos = new List<string>(ComboBox1.SelectedItems.Count);
                    foreach (Ext.Net.SelectedListItem i in ComboBox1.SelectedItems)
                    {
                        tipos.Add(i.Text);
                    }

                    Session["Report"] =
                        IU.Contabilidad.ContabilidadGlobal.Admin.ConsultaLibroDiario(
                            tipos.ToArray(),
                            DateFieldDesde.SelectedDate,
                            DateFieldHasta.SelectedDate);
                }
                else
                {
                    Session["Report"] = 
                        IU.Contabilidad.ContabilidadGlobal.Admin.ConsultaLibroDiario(
                            null,
                            DateFieldDesde.SelectedDate,
                            DateFieldHasta.SelectedDate);
                }

                Response.Redirect("LibroDiario.aspx");
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcion(ex, "Error");
            }
        }
    }
}
