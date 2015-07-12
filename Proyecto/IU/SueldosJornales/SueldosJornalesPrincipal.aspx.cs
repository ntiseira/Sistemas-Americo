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

namespace IU.SueldosJornales
{
    public partial class SueldosJornalesPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
                //CategoriasSueldosView.Visible = false;
                //MultiView1.SetActiveView(PrincipalView);
            //}
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //listado de categorías de sueldos
            if (Menu1.SelectedValue == "2")
            {
                //MultiView1.Visible = true;
                MultiView1.SetActiveView(CategoriasSueldosView);
                CategoriasSueldos1.OnShow();
            }
            else if (Menu1.SelectedValue == "5")
            {
                //MultiView1.Visible = true;
                MultiView1.SetActiveView(DatosEmpleadorView);
                DatosEmpleador1.OnShow();
            }
            else if (Menu1.SelectedValue == "8")
            {
                //MultiView1.Visible = true;
                MultiView1.SetActiveView(LugaresPagoView);
                LugaresDePago1.OnShow();
            }
        }
    }
}
