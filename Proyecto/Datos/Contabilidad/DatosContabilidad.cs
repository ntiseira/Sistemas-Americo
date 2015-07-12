using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

#warning Hacer método acceder

namespace CapaDatos.Contabilidad
{
    public static class DatosContabilidad
    {
        #region CONSULTAS SELECT

        public static DataSet ObtenerListaTiposAsientos(long codEmpresa)
        {
            return Datos.Consultar("SELECT t.descripcion as \"Descripción\", t.habilitado as \"Habilitado\" FROM tipoasiento t WHERE t.empresa_idempresa = " + codEmpresa.ToString());
        }

        /// <summary>
        /// Obtiene la descripción de cada asiento habilitado correspondiente a una empresa.
        /// </summary>
        /// <param name="codEmpresa">Código de la empresa.</param>
        /// <returns></returns>
        public static DataSet ObtenerDescripTiposAsientos(long codEmpresa)
        {
            return Datos.Consultar("SELECT t.descripcion FROM tipoasiento t WHERE t.habilitado = 1 AND t.empresa_idempresa = " + codEmpresa.ToString());
        }

        public static DataSet ObtenerListaTiposMovimientos(long codEmpresa)
        {
            return Datos.Consultar("SELECT t.descripcion FROM tipomovimiento t WHERE t.habilitado = 1 AND t.empresa_idempresa = " + codEmpresa.ToString());
        }

        /// <summary>
        /// Obtiene un listado con el código y la razón social de TODOS los 
        /// clientes de una empresa.
        /// </summary>
        /// <param name="codEmpresa"></param>
        /// <returns></returns>
        public static DataSet ObtenerListaClientes(long codEmpresa)
        {
            return Datos.Consultar(
                string.Format("SELECT c.codcliente, c.razonsocial FROM cliente c WHERE c.empresa_idempresa = {0} AND c.tipocliente_empresa_idempresa = {0};", codEmpresa.ToString()));
        }

        /// <summary>
        /// Obtiene un listado con el código y la razón social de TODOS los 
        /// proveedores de una empresa.
        /// </summary>
        /// <param name="CodEmpresa"></param>
        /// <returns></returns>
        public static DataSet ObtenerListaProveedores(long codEmpresa)
        {
            return Datos.Consultar(
                string.Format("SELECT c.idproveedor, c.razonsocial FROM proveedor c WHERE c.empresa_idempresa = {0} AND c.tipoproveedor_empresa_idempresa = {0};", codEmpresa.ToString()));
            
        }

        /// <summary>
        /// Obtiene la fecha de inicio de un período de ejercicio.
        /// </summary>
        /// <param name="codEjercicio"></param>
        /// <param name="codEmpresa"></param>
        /// <returns></returns>
        public static DataSet ObtenerInicioEjercicio(long codEjercicio, long codEmpresa)
        {
            return Datos.Consultar(
                string.Format(
                "SELECT ej.fechainicio FROM ejercicio ej WHERE ej.codejercicio = {1} AND ej.empresa_idempresa = {0};"
                , codEmpresa, codEjercicio));
        }

        /// <summary>
        /// Obtiene la fecha de fin de un período de ejercicio.
        /// </summary>
        /// <param name="codEjercicio"></param>
        /// <param name="codEmpresa"></param>
        /// <returns></returns>
        public static DataSet ObtenerFinEjercicio(long codEjercicio, long codEmpresa)
        {
            return Datos.Consultar(
                string.Format(
                "SELECT ej.fechafin FROM ejercicio ej WHERE ej.codejercicio = {1} AND ej.empresa_idempresa = {0};"
                , codEmpresa, codEjercicio));
        }

        /// <summary>
        /// Obtiene el código y la descripción de los planes de cuenta de una empresa para un determinado ejercicio.
        /// </summary>
        /// <param name="codEmpresa"></param>
        /// <param name="codEjercicio"></param>
        /// <returns></returns>
        public static DataSet ObtenerPlanesDeCuentas(long codEmpresa, long codEjercicio)
        {
            return Datos.Consultar(
                   string.Format(
                   "SELECT p.codPlanCuentas, p.descripcion FROM plancuentas p WHERE p.ejercicio_codejercicio = {1} AND p.ejercicio_empresa_idempresa = {0};"
                   , codEmpresa, codEjercicio));
        }

        public static DataSet Acceder(long codEmpresa, long codSucursal, long codEjercicio, string codPuesto)
        {
            return Datos.Consultar(
                string.Format(
                "SELECT * FROM Empresa e, Sucursal s, Ejercicio ej, PuestoTrabajo p WHERE e.idempresa = {0} AND e.idempresa = ej.empresa_idempresa AND ej.codEjercicio = {1} AND p.empresa_idempresa = e.idempresa AND p.descripcion = '{2}' AND s.empresa_idempresa = e.idempresa AND s.codigosucursal = {3};"
                , codEmpresa, codEjercicio, codPuesto, codSucursal));
        }
        #endregion

        #region CONSULTAS INSERT

        public static void AltaTipoAsiento(string descrip, bool habilitado, long codEmpresa)
        {
            Datos.ConsultarEx(
                String.Format("INSERT INTO tipoasiento (descripcion,habilitado,codEmpresa) VALUES (\"{0}\", {1}, {2})",
                descrip, habilitado ? 1 : 0, codEmpresa)
                );
        }

        public static void AltaTipoMovimiento(string descrip, bool habilitado, long codEmpresa)
        {
            Datos.ConsultarEx(
                String.Format("INSERT INTO tipomovimiento (descripcion,habilitado,codEmpresa) VALUES (\"{0}\", {1}, {2})",
                descrip, habilitado ? 1 : 0, codEmpresa)
                );
        }
        #endregion

        #region CONSULTAS UPDATE

        #endregion

        #region CONSULTAS DELETE

        #endregion

    }
}
