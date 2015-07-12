using System;
using System.Collections;
using System.Collections.Generic;
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
using VentasCuentasCobrar;
using Ext.Net;
using VentasCuentasCobrar.CLIENTES;

namespace IU.VentasCuentasCobrar.Reportes.IvaVentas
{
    public partial class PrepararLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                ComboBox1.Items.Clear();
                
                AdministradorVentas admin = new AdministradorVentas();

                ArrayList lista = new ArrayList();
                  lista = admin.darClientes();
               int i = 0;
                while (i < lista.Count)
                {                   
                   
                    ComboBox1.Items.Add(new Ext.Net.ListItem(lista[2].ToString()));
               
                    i++;               
                }

                        
                    
                ComboBox1.DataBind();
            }          
        }




    }//clase
}//namespace
