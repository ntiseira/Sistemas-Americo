using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AdministradorGeneral.Seguridad;
using CapaDatos;
using CapaDatos.AdministradorGeneral;
using CapaDatos.Contabilidad;
using Entidades;
using PhantomDb.Entidades;

namespace VentasCuentasCobrar
{
    public class AdministradorVentas
    {
        public AdministradorVentas()
        { 
        
        }

        /// <summary>
        /// Crea los datos adicionales de un cliente.
        /// </summary>
        /// <param name="codcli"></param>
        public static void CrearDatosSiNoExisten(int codcli)
        {
            var phantom = CapaDatos.Datos.Phantom;
            var cliente = (Entity_cliente)phantom.Cargar(
                typeof(Entity_cliente), 
                string.Format("codcliente={0} AND empresa_idempresa={1}", codcli, ModuloSoporte.Global.CodEmpresa));

            var otrosdatos = new Entity_clienteotrosdatos
            {
                Cliente_codcliente = codcli,
                Cliente_empresa_idempresa = cliente.Empresa_idempresa
            };

            if (!phantom.Existe(otrosdatos))
            {
                phantom.Insertar(otrosdatos);
            }

            var datosimpositivos = new Entity_clientedatosimpositivos
            {
                Cliente_codcliente = codcli,
                Cliente_empresa_idempresa = cliente.Empresa_idempresa,
                Situacioniva = Documento.DefaultSituacionIva
            };

            if (!phantom.Existe(datosimpositivos))
            {
                phantom.Insertar(datosimpositivos);
            }
             
        }


       
        public static bool registrarComprobante(DateTime fecha,  int codCliente,  string letra,
                int numero, DateTime fechaEntrega, DateTime fechaEmision, DateTime fechaContabilizacion,
                DateTime fechaDeclaracionJurada, int prov, bool bienUso, List<Entity_lineaVenta> listaItems, double total,
            bool habilitado, int regimenEspecial, double totalNeto, double totalIva, double totalRecargos,
            double totalDescuentos, double totalOtros, int nroTalonario, int tipoLista, long empresa, int talonario_sucursal_codigoSucursal, string talonario_tiposcomprobante_idtipocomprobante, int moneda)

        {

            bool respu = false;

            try
            {
                if (Datos.AgregarComprobanteVenta(fecha, codCliente, letra, numero, tipoLista, empresa, fechaEntrega, fechaEmision, fechaContabilizacion, fechaDeclaracionJurada, bienUso, prov, total, habilitado, regimenEspecial, totalNeto, totalIva, totalRecargos, totalDescuentos, totalOtros, nroTalonario, talonario_sucursal_codigoSucursal, talonario_tiposcomprobante_idtipocomprobante, moneda))
                {
                    int i = 0;
                    while (i <listaItems.Count)
                    {                       
                     Datos.AgregarLineaVenta(numero,listaItems[i].Concepto_codConcepto, moneda, listaItems[i].Cantidad, listaItems[i].Importe, nroTalonario, talonario_sucursal_codigoSucursal, talonario_tiposcomprobante_idtipocomprobante, empresa);
                     i++;
                    }
                    respu = true;

                }
                return respu;
            }
            catch (Exception ex)
            {
                respu = false;
                return respu;            
            }  
        
        }


        public static string ObtenerClienteSituacionIVa(int cliente)
        {

            DataSet data = Datos.ConsultarSituacionImpositiva(cliente);
            object situacionIva;
            if (data.Tables[0].Rows.Count >0)
            {
                situacionIva = data.Tables[0].Rows[0].ItemArray[0];
            }
            else {

                situacionIva = "No tiene situacion iva";
            
            }
            return situacionIva.ToString();
        
        }


        public static DataSet ObtenerResumenDeCuenta(int cliente)
        {         
        
            ArrayList array = AdministradorVentas.ObtenerClienteNroCuenta(cliente);
            int nroCuenta = 0;
            int idBanco = 0;
            double saldo = 0;
            if (array.Count > 0)
            {
                nroCuenta = int.Parse(array[0].ToString());
                saldo = double.Parse(array[1].ToString());
                idBanco = int.Parse(array[2].ToString());
            }

            DataSet data = Datos.ObtenerResumenDeCuenta(cliente,nroCuenta,idBanco);

            return data;


        }



        public static bool ingresarSaldoyAjustes(int nroCuenta, double debe, double haber, string motivo)
        {
            return Datos.ingresarSaldoyAjustes(nroCuenta, debe, haber);
        
        }

        public static bool RegistrarCobranza(DateTime fecha, int nroCuenta, double ImporteNeto, double ImporteBruto, int codcliente, long empresa, string descripcion, string tipoMovimiento, int idBanco, double saldo)
        {
            bool respu = false;
            if (Datos.RegistrarCobranza(fecha, ImporteNeto, ImporteBruto, codcliente, empresa))
            { 
                respu = Datos.ingresarSaldoyAjustes(nroCuenta, 0, ImporteBruto);
                respu = Datos.RegistrarMovimiento(fecha, ImporteNeto, descripcion, tipoMovimiento, empresa, nroCuenta, idBanco, codcliente, saldo);
            }

            return respu;
        }


        public static bool RegistrarComprobanteAnulado
            (DateTime fecha, int talonario, string tipoComprobante, int sucursal, int moneda, int nroComprobante, int empresa)
        {
            bool respu = false;
            if (Datos.RegistrarComprobanteAnulado(fecha, talonario, tipoComprobante, sucursal, moneda, nroComprobante, empresa))
            {
                respu = Datos.ingresarComprobanteAnulado(nroComprobante);
            }
            return respu;
        }




        public static ArrayList ObtenerNroTalonario(int tipoComprobante)
        {

            ArrayList data = Datos.ObtenerTalonario(tipoComprobante);    

            return data;
        }

        public static ArrayList ObtenerClienteNroCuenta(int cliente)
        {

            DataSet data = Datos.ConsultarNroCuenta(cliente);
           
            ArrayList array = new ArrayList();

            if (data.Tables[0].Rows.Count > 0)
            {
                array.Add(int.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString()));
                array.Add(double.Parse(data.Tables[0].Rows[0].ItemArray[1].ToString()));
                array.Add(int.Parse(data.Tables[0].Rows[0].ItemArray[2].ToString()));

            }

            return array;

        }



        public static ArrayList ObtenerDescuentoFinanciero(int nroDescuento)
        {

            ArrayList data = Datos.ObtenerDescuentoFinanciero(nroDescuento);

            return data;
        }

        public static ArrayList ObtenerDescuentoComercial(int nroDescuento)
        {

            ArrayList data = Datos.ObtenerDescuentoComercial(nroDescuento);

            return data;
        }



        public static void IncrementarNroTalonario(int nroTalonario)
        {
            Datos.IncrementarNroTalonarioUtilizado(nroTalonario);        
        }

        public static void ingresarCompensacionComprobante(int numeroComprobante, double total, double totalAplicar)
        {
            Datos.ingresarCompensacionComprobante(numeroComprobante, totalAplicar);
        }



    }//clase
}//namespace
