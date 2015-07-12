using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasCuentasCobrar;

namespace ComprasCuentasPagar
{
    public class Proveedor
    {

        private long codigo;
        private string razonSocial;
        private bool habilitado; //ver aca
        private string domicilio;
        private string localidad;
        private Provincia provincia;
        private long telefono;
        private string mail;
        private int condicionPago; //ver aca
        private string descripcionCondicionPago;
        private string codigoPostal; //ver si es string o numero, xq hay algunos registros q los ingresan con letras ahora, ver regulacion de la afip
        private int fax;
        private string contacto; //otros datos
        private string paginaWeb;//otros datos
        private string nota;//otros datos


        public Proveedor() 
        {
        }
    }
}
