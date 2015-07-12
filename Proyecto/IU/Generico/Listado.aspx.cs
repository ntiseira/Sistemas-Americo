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

namespace IU.Generico
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += new EventHandler(Listado_LoadComplete);
        }

        void Listado_LoadComplete(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            this.ControlListar1.DataSource = Session["listado"];
            this.ControlListar1.OnShow();
        }
    }
}
