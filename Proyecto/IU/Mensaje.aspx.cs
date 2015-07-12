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

namespace IU
{
    public partial class Mensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mensaje = Session["Mensaje"].ToString();
            string titulo = Session["Titulo"].ToString();
            string html = "";

            if (!titulo.Equals(""))
            {
                html = string.Format("<b><i>{0}</i></b><br/><br/>", titulo);
            }

            html += mensaje + "<br/>";

            this.Panel1.Html = html;
        }
    }
}
