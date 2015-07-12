using System;
using System.IO;
using System.Net;

namespace IU.Generico
{
    public partial class CotizacionDolar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ruta = "http://www.nicolasgenen.com.ar/wsdolar.php";
                WebRequest request = WebRequest.Create(ruta);
                WebResponse response = request.GetResponse();
                StreamReader r = new StreamReader(response.GetResponseStream());
                string cotizacionXML = r.ReadToEnd();
                Label2.Text = "Fecha: " + cotizacionXML.Substring(37,10); //fecha
                Label3.Text = "Hora: " + cotizacionXML.Substring(65, 8);  //hora
                Label4.Text = "Valor de Compra: " + cotizacionXML.Substring(118, 4); //compra
                Label5.Text = "Valor de Venta: " + cotizacionXML.Substring(165, 4); //venta
                //formato: fecha/hora/valorCompra/valorVenta
            }
            catch
            {
            }
        }
    }
}