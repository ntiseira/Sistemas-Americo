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

namespace IU.Contabilidad.TipoAsiento
{
    public partial class FormListarTiposAsientos : System.Web.UI.UserControl, IControlView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        #region IControlView Members

        public void OnShow()
        {
            GridView1.DataSource = ContabilidadGlobal.Admin.ObtenerListaTiposAsientos();
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        #endregion
    }
}