//#define PROBARCOTIZACIONES

using System;
using AdministradorGeneral;
using Siscont.AdministradorGeneral.Tablas;
using AdministradorGeneral.Parsers;
using Entidades;
using CapaDatos.AdministradorGeneral;

namespace AdministradorGeneral
{
    public class Administrador
    {
        /// <summary>
        /// Actualiza los valores de las cotizaciones en la base de datos, cada cuatro horas.
        /// </summary>
        public static void ActualizarCotizaciones()
        {
#if !PROBARCOTIZACIONES
            if ((DateTime.UtcNow - GetUltimaFecha(Moneda.Dolar).ToUniversalTime()).TotalHours >= 4)
#endif
            {
                try
                {
                    var parserPage1 = new ParserCotizacionDolar();
                    parserPage1.Parsear();

                    GuardarCambio(Moneda.Dolar, parserPage1.DolarCompra, parserPage1.DolarVenta);
                    GuardarCambio(Moneda.Euro, parserPage1.EuroCompra, parserPage1.EuroVenta);

                    System.Diagnostics.Debug.WriteLine("Euro y dólar actualizados");
                }
                catch
                {
                    try
                    {
                        var parserPage1 = new ParserDolarDia();
                        parserPage1.Parsear();

                        GuardarCambio(Moneda.Dolar, parserPage1.DolarCompra, parserPage1.DolarVenta);
                        GuardarCambio(Moneda.Euro, parserPage1.EuroCompra, parserPage1.EuroVenta);

                        System.Diagnostics.Debug.WriteLine("Euro y dólar actualizados");
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Si el cambio cambió, guardar el nuevo valor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="compra"></param>
        /// <param name="venta"></param>
        private static void GuardarCambio(int id, float compra, float venta)
        {
            var ultimoCambio = GetUltimoCambio(id);
            if (ultimoCambio == null || compra != ultimoCambio.Compra || venta != ultimoCambio.Venta)
            {
                var cambio = new Entidades.Entity_cambiomoneda();
                cambio.Compra = compra;
                cambio.Venta = venta;
                cambio.Moneda_idmoneda = id;
                cambio.Fechacambio = DateTime.Now;

                DatosAdministradorGeneral.InsertarMoneda(cambio);
            }
        }

        public static Entity_cambiomoneda GetUltimoCambio(int idmoneda)
        {
            return DatosAdministradorGeneral.ObtenerUltimoCambio(idmoneda);
        }

        private static DateTime GetUltimaFecha(int idmoneda)
        {
            try
            {
                var ds = CapaDatos.Datos.Consultar
                    (
                        string.Format(
                            "SELECT c.fechacambio FROM cambiomoneda c WHERE c.moneda_idmoneda={0} AND c.fechacambio NOT IN (" +
                            "SELECT c1.fechacambio FROM cambiomoneda c1, cambiomoneda c2 WHERE c1.moneda_idmoneda={0} AND c2.moneda_idmoneda={0} AND c1.fechacambio < c2.fechacambio)",
                            idmoneda
                            )
                    );

                return DateTime.Parse(CapaDatos.Datos.GetValor(ds).ToString());
            }
            catch
            {
                return DateTime.Now.AddDays(-2);
            }
        }
    }
}
