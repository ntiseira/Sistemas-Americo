using System;
using System.Collections.Generic;
using Siscont.Contabilidad;
using Ext.Net;

namespace IU.Contabilidad.Libros
{
    public partial class LibroDiario : System.Web.UI.Page
    {
        private string formato = "Fecha: {0},   Número: {1},   Concepto: {2}";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                List<object> data = new List<object>();
                List<Siscont.Contabilidad.Asiento> asientos = (List<Siscont.Contabilidad.Asiento>)Session["Report"];

                foreach (Siscont.Contabilidad.Asiento a in asientos)
                {
                    string group = string.Format(formato, a.Fecha.ToShortDateString(), a.IdAsiento, a.Tipoasiento_descripcion);
                    List<object> custom = new List<object>();

                    foreach (Movimiento mov in a.Movimientos)
                    {
                        custom.Add(mov.GetLineaLibroDiario());
                    }

                    data.Add(new { Letter = group, Customers = custom });
                }

                this.dsReport.DataSource = data;
                this.dsReport.DataBind();
            }
        }
    }
}
