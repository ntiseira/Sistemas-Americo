using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AdministradorGeneral.Parsers
{
    public class ParserDolarDia: IParser, IParserDolar, IParserEuro
    {
        private const string Start = "";
        private const string End = "";

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

        float realCompra;
        public float RealCompra
        {
            get { return realCompra; }
            set { realCompra = value; }
        }

        float realVenta;
        public float RealVenta
        {
            get { return realVenta; }
            set { realVenta = value; }
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
            string website = Parser.GetSourceCode("http://www.dolaraldia.com/rss/botoncotizaciones08.php?MS=1");

            // Algunos cortes
            Parser.GetContentAndCutEnd(ref website, "<table ", "</table>");
            Parser.GetContentAndCutEnd(ref website, "<table ", "</table>");

            Parser.GetContentAndCut(ref website, "<tr", "</tr>");
            Parser.GetContentAndCut(ref website, "<td ", "</td>");
            DolarCompra = GetValor(ref website);
            DolarVenta = GetValor(ref website);
            Parser.GetContentAndCut(ref website, "<td ", "</td>");
            EuroCompra = GetValor(ref website);
            EuroVenta = GetValor(ref website);
            Parser.GetContentAndCut(ref website, "<td ", "</td>");
            RealCompra = GetValor(ref website);
            RealVenta = GetValor(ref website);
        }

        private float GetValor(ref string website)
        {
            var cultura = CultureInfo.CreateSpecificCulture("en-US");
            var str = Parser.GetContentAndCut(ref website, "<td ", "</td>");
            str = Parser.GetContent(str, "<b>", "</b>");
            return float.Parse(str, cultura);
        }
    }
}
