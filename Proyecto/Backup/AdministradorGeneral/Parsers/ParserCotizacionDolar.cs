
using System.Globalization;
using System;
namespace AdministradorGeneral.Parsers
{
    /// <summary>
    /// Obtiene el valor del dólar y del euro.
    /// </summary>
    public class ParserCotizacionDolar : IParserDolar, IParserEuro, IParser
    {
        private const string Start = "<td class=\"cotizaciones3\"";
        private const string End = "</td>";

        float dolarCompra;
        public float DolarCompra
        {
            get { return dolarCompra; }
            set { dolarCompra = value; }
        }

        float dolarVenta;
        public float DolarVenta
        {
            get { return dolarVenta; }
            set { dolarVenta = value; }
        }

        float euroCompra;
        public float EuroCompra
        {
            get { return euroCompra; }
            set { euroCompra = value; }
        }

        float euroVenta;
        public float EuroVenta
        {
            get { return euroVenta; }
            set { euroVenta = value; }
        }

        public void Parsear()
        {
            string website = Parser.GetSourceCode("http://www.cotizacion-dolar.com.ar");

            var strDolarCompra = Parser.GetContentAndCut(ref website, Start, End);
            var strDolarVenta = Parser.GetContentAndCut(ref website, Start, End);
            var strEuroCompra = Parser.GetContentAndCut(ref website, Start, End);
            var strEuroVenta = Parser.GetContentAndCut(ref website, Start, End);
            var cultura = CultureInfo.CreateSpecificCulture("en-US");

            DolarCompra = float.Parse(strDolarCompra, cultura);
            DolarVenta = float.Parse(strDolarVenta, cultura);
            EuroCompra = float.Parse(strEuroCompra, cultura);
            EuroVenta = float.Parse(strEuroVenta, cultura);
        }
    }
}
