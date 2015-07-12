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


       
        public static bool registrarComprobante(DateTime fecha,  int codCliente,
                char letra,
                long numero,
                DateTime fechaEntrega,
                DateTime fechaEmision,
                int lote,
                string mensaje,
                DateTime fechaContabilizacion,
                DateTime fechaDeclaracionJurada,
                int prov,             
                bool bienUso, List<ItemComprobante> listaItems  , double total   
            
            )
        {



            Entity_comprobanteVenta datos = new Entity_comprobanteVenta();

            datos.Bienuso = bienUso;
            //datos.Causaemision
            datos.Cliente_codcliente = codCliente;
            //datos.Codtipooperacion
          //  datos.Descuentofinanciero = 
           //datos.Diasmantoferta
            datos.Lote = lote;
            datos.Mensaje = mensaje;
            datos.Periododeclaracionjurada = fechaDeclaracionJurada;
            datos.Plazosentrega = fechaEntrega;
            datos.Provincia = prov;
            datos.Total = total;

            foreach (ItemComprobante m in listaItems)
            {

                Entity_lineaVenta linea = new Entity_lineaVenta();
                linea.Cantidad = (int)m.Cantidad;
                linea.CodConcepto = m.Concepto;
                linea.Importe = m.Importe;

                //INSERTO LA LINEA DE VENTA DE LOS ITEMS
                Datos.Phantom.Insertar(linea);            
            }

            Datos.Phantom.Insertar(datos);

            

        
        return true;
        
        }

    }//clase
}//namespace
