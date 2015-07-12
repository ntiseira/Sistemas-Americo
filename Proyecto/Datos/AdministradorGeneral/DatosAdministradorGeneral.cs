using System;
using System.Data;
using Entidades;

namespace CapaDatos.AdministradorGeneral
{
    public class DatosAdministradorGeneral
    {
        #region SELECT

        public static DataSet ObtenerPuestosDeTrabajo(long codEmpresa)
        {
            return Datos.Consultar(
                String.Format(
                "SELECT p.descripcion FROM puestotrabajo p WHERE p.habilitado=1 AND p.empresa_idempresa = {0} ORDER BY p.descripcion;"
                , codEmpresa));
        }

        public static DataSet ObtenerListaEmpresas(string usuario)
        {
            return Datos.Consultar(
                string.Format("SELECT e.idempresa, e.razonsocial FROM Empresa e, Empresa_has_usuarios eu WHERE e.idempresa = eu.empresa_idEmpresa AND eu.usuarios_usuario = '{0}'", usuario));
        }

        public static DataSet ObtenerEjercicios(long codEmpresa)
        {
            return Datos.Consultar(
                String.Format(
                //@"SELECT e.codEjercicio, DATE_FORMAT(e.fechaInicio, %d-%m-%Y), e.fechaFin, e.estado FROM Ejercicio e WHERE e.empresa_idempresa = {0};"
                @"SELECT e.codEjercicio, e.fechaInicio, e.fechaFin, e.estado FROM Ejercicio e WHERE e.empresa_idempresa = {0};"
                , codEmpresa));
        }

        public static DataSet ObtenerListaSucursales(long codEmpresa)
        {
            return Datos.Consultar(
                String.Format(
                "SELECT e.codigosucursal, e.descripcion, e.casacentral FROM Sucursal e WHERE e.empresa_idempresa = {0};"
                , codEmpresa));
        }


        public static Entity_cambiomoneda ObtenerUltimoCambio(int idmoneda)
        {
            try
            {
                var cambio = (Entity_cambiomoneda)Datos.Phantom.Cargar(typeof(Entity_cambiomoneda),
                    string.Format("moneda_idmoneda={0} AND fechacambio NOT IN (SELECT c.fechacambio FROM cambiomoneda c, cambiomoneda c2 WHERE c.moneda_idmoneda={0} AND c2.moneda_idmoneda={0} AND c.fechacambio < c2.fechacambio )", idmoneda));

                return cambio;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region INSERT
        public static void InsertarMoneda(Entity_cambiomoneda cambio)
        {
            CapaDatos.Datos.ConsultarEx(
                String.Format("INSERT INTO cambiomoneda(Fechacambio,Compra,Venta,Moneda_idmoneda) VALUES ('{0}',{1},{2},{3});",
                    cambio.Fechacambio.ToString("yyyy-MM-dd HH:mm:ss"), 
                    cambio.Compra.ToString().Replace(',', '.'), 
                    cambio.Venta.ToString().Replace(',', '.'), 
                    cambio.Moneda_idmoneda));
        }      
        #endregion

        #region DELETE


        #endregion

        #region UPDATE
 

        #endregion


    }//clase
}//namespace
