using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebHelper;
using ModuloSoporte;
using SueldosJornales;

namespace IU.SueldosJornales
{
    public partial class ConsultarCategoriaSueldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlList1.Tipo = typeof(CategoriaSueldo);
            this.ModuloFiltro1.Tip = typeof(CategoriaSueldo);
            this.ControlList1.Titulo = "Consulta de categoría de Sueldos";
            this.ControlList1.Descripcion = "Permite consultar una categoría de sueldos de los empleados.";
            this.ControlList1.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", long.Parse(Global.CodEmpresa.ToString())) };
            this.ControlList1.OnShow();
        }



    }
}
