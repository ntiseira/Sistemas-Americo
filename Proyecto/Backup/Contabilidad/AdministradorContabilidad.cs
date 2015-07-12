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

namespace Siscont.Contabilidad
{
    public enum TipoListado
    {
        Reducido,
        Completo
    }

    public class AdministradorContabilidad
    {
        #region Atributos
        public string Usuario
        {
            get { return ModuloSoporte.Global.Usuario; }
            set 
            {
                ModuloSoporte.Global.Usuario = value; 
            }
        }

        long codEmpresa = 0;
        public long CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }

        long codSucursal = 0;
        public long CodSucursal
        {
            get { return codSucursal; }
            set { codSucursal = value; }
        }

        long codEjercicio = 0;
        public long CodEjercicio
        {
            get { return codEjercicio; }
            set { codEjercicio = value; }
        }

        int codPlanCuentas = 1;
        public int CodPlanCuentas
        {
            get { return codPlanCuentas; }
            set { codPlanCuentas = value; }
        }

        string codPuesto = "";
        public string CodPuesto
        {
            get { return codPuesto; }
            set { codPuesto = value; }
        }

        Permisos permisos = Permisos.PermisosGuest;
        public Permisos Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }
        #endregion

        public AdministradorContabilidad()
        {

        }

        public bool Logueado
        {
            get { return !Usuario.Equals(""); }
        }

        #region Métodos sin login
        public IList ObtenerSucursales(long codEmpresa)
        {
            DataSet ds = DatosAdministradorGeneral.ObtenerListaSucursales(codEmpresa);
            return (IList)Datos.GetTotalValores(ds);
        }

        public IList ObtenerListaEmpresas(string usuario)
        {
            DataSet ds = DatosAdministradorGeneral.ObtenerListaEmpresas(usuario);
            return (IList)Datos.GetTotalValores(ds);
        }

        public IList ObtenerEjercicios(long codEmpresa)
        {
            DataSet ds = DatosAdministradorGeneral.ObtenerEjercicios(codEmpresa);
            return (IList)Datos.GetTotalValores(ds);
        }

        public IList ObtenerPuestosDeTrabajo(long codEmpresa)
        {
            DataSet ds = DatosAdministradorGeneral.ObtenerPuestosDeTrabajo(codEmpresa);
            return (IList)Datos.GetTotalValores(ds);
        }

        public IList ObtenerPlanesDeCuentas(long codEmpresa, long codEjercicio)
        {
            var ds = DatosContabilidad.ObtenerPlanesDeCuentas(codEmpresa, codEjercicio);
            return (IList)Datos.GetTotalValores(ds);
        }

        public void Acceder(long codEmpresa, long codSucursal, long codEjercicio, string codPuesto, int codPlan)
        {
            DataSet ds = DatosContabilidad.Acceder(codEmpresa, codSucursal, codEjercicio, codPuesto);
            if (Datos.EstaVacio(ds))
                throw new Exception("No se ha podido loguear, debido a que algún dato es incorrecto.");
            this.CodEjercicio = codEjercicio;
            this.CodEmpresa = codEmpresa;
            this.CodPuesto = codPuesto;
            this.CodSucursal = codEjercicio;
            this.CodPlanCuentas = codPlan;
            ModuloSoporte.Global.NombreEmpresa = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            var permisos = new Entity_empresa_has_usuarios { Empresa_idempresa=codEmpresa, Usuarios_usuario=this.Usuario};
            permisos = (Entity_empresa_has_usuarios)Datos.Phantom.Cargar(permisos);

            this.Permisos = new Permisos { Grado=permisos.Permisos};
        }
        #endregion

        #region Listados
        public object ObtenerListaTiposAsientos()
        {
            DataSet ds = DatosContabilidad.ObtenerListaTiposAsientos(CodEmpresa);
            return ds;
        }

        public object[] ObtenerDescripTiposAsientos()
        {
            DataSet ds = DatosContabilidad.ObtenerDescripTiposAsientos(CodEmpresa);
            return Datos.GetTotalValores(ds, 0);
        }

        public object[] ObtenerListaDescripTiposAsientos()
        {
            DataSet ds = DatosContabilidad.ObtenerDescripTiposAsientos(CodEmpresa);
            object[] datos = new object[Datos.GetTotalValores(ds, 0).Length];
            int i = 0;
            foreach (object o in Datos.GetTotalValores(ds, 0))
            {
                datos[i++] = new object[] { o.ToString() };
            }

            return datos;
        }

        public object[] ObtenerListaTiposMovimientos()
        {
            DataSet ds = DatosContabilidad.ObtenerListaTiposMovimientos(CodEmpresa);
            object[] datos = new object[Datos.GetTotalValores(ds, 0).Length];
            int i = 0;
            foreach (object o in Datos.GetTotalValores(ds, 0))
            {
                datos[i++] = new object[] { o.ToString() };
            }

            return datos;
        }

        /// <summary>
        /// Obtiene el código y la razón social de todos los clientes de la empresa logueada.
        /// </summary>
        /// <returns></returns>
        public object[] ObtenerListaClientes()
        {
            DataSet ds = DatosContabilidad.ObtenerListaClientes(CodEmpresa);
            object[] datos = new object[Datos.GetTotalValores(ds, 0).Length];
            int i = 0;
            foreach (object[] o in Datos.GetTotalValores(ds))
            {
                datos[i++] = new object[] { o[0].ToString(), o[1].ToString() };
            }

            return datos;
        }

        /// <summary>
        /// Obtiene el código y la razón social de todos los proveedores de la empresa logueada.
        /// </summary>
        /// <returns></returns>
        public object[] ObtenerListaProveedores()
        {
            DataSet ds = DatosContabilidad.ObtenerListaProveedores(CodEmpresa);
            object[] datos = new object[Datos.GetTotalValores(ds, 0).Length];
            int i = 0;
            foreach (object[] o in Datos.GetTotalValores(ds))
            {
                datos[i++] = new object[] { o[0].ToString(), o[1].ToString() };
            }

            return datos;
        }

        public object ObtenerListaDepartamentos()
        {
            throw new NotImplementedException();
        }

        public object ObtenerListaAreas()
        {
            throw new NotImplementedException();
        }

        public object ObtenerListaCentrosDeCosto()
        {
            throw new NotImplementedException();
        }

        public object ObtenerListadoPlanDeCuentas(TipoListado tipo, DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Libros

        /// <summary>
        /// Obtiene los asientos que serán listados en el libro diario.
        /// </summary>
        /// <param name="tipos">Tipos. En caso de ser null, lista todos los tipos.</param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        public List<Asiento> ConsultaLibroDiario(string [] tipos, DateTime desde, DateTime hasta)
        {
            StringBuilder sbWhere = new StringBuilder();

            // Filtro "Fecha"
            if (desde != null)
            {
                sbWhere.Append("(");
                sbWhere.Append("fecha >= ");
                sbWhere.Append("'");
                sbWhere.Append(desde.ToString("yyyy-MM-dd"));
                sbWhere.Append("')");
            }

            if (hasta != null)
            {
                sbWhere.Append("(");
                sbWhere.Append("fecha <= ");
                sbWhere.Append("'");
                sbWhere.Append(hasta.ToString("yyyy-MM-dd"));
                sbWhere.Append("')");
            }

            // Filtro "Tipo de asiento"
            if (tipos != null)
            {
                sbWhere.Append("(tipoasiento_descripcion = '");
                sbWhere.Append(tipos[0]);
                for(int i = 1; i < tipos.Length; i++)
                {
                    sbWhere.Append("' or tipoasiento_descripcion = '");
                    sbWhere.Append(tipos[i]);
                }
                sbWhere.Append("')");
            }

            // Ejercicio correspondiente
            sbWhere.Append("(");
            sbWhere.Append("ejercicio_codejercicio = ");
            sbWhere.Append(CodEjercicio);
            sbWhere.Append(" AND ejercicio_empresa_idempresa = ");
            sbWhere.Append(CodEmpresa);
            sbWhere.Append(")");
            string where = sbWhere.ToString().Replace(")(", ") AND (");
            
            // Consulta (nueva)
            List<Asiento> asientos = new List<Asiento>();
            IList asientus = Datos.Phantom.Listar(typeof(Entity_asiento), where);
            foreach (Entity_asiento asiento in asientus)
            {
                asientos.Add(new Asiento(asiento));
            }
            return asientos;
        }
        #endregion

        public DateTime ObtenerInicioEjercicio()
        {
            return DateTime.Parse(Datos.GetValor(
                    DatosContabilidad.ObtenerInicioEjercicio(
                        this.CodEjercicio, this.CodEmpresa)).ToString());
        }

        public DateTime ObtenerFinEjercicio()
        {
            return DateTime.Parse(Datos.GetValor(
                    DatosContabilidad.ObtenerFinEjercicio(
                        this.CodEjercicio, this.CodEmpresa)).ToString());
        }

        public int GenerarAsiento(
            string descripcion, 
            string tipo, 
            DateTime fecha,
            bool editable, 
            bool habilitado, 
            bool sistema,
            PreMovimiento[] premovimientos)
        {
            if (premovimientos.Length == 0)
            {
                throw new Exception("El asiento no se ha podido registrar debido a que no tiene movimientos asignados.");
            }

            Entity_asiento datos = new Entity_asiento();
            datos.Habilitado = habilitado;
            datos.Generadosistema = sistema;
            datos.Fecha = fecha;
            datos.Descripcion = descripcion;
            datos.Editable = editable;
            datos.Ejercicio_codejercicio = (int)this.CodEjercicio;
            datos.Ejercicio_empresa_idempresa = this.CodEmpresa;
            datos.Tipoasiento_empresa_idempresa = this.CodEmpresa;
            datos.Tipoasiento_descripcion = tipo;

            var movimientos = new List<Movimiento>(premovimientos.Length);
            int i = 0;
            foreach (PreMovimiento m in premovimientos)
            {
                Movimiento mov = new Movimiento(m);
                mov.Cod = ++i;
                mov.Datos.Asiento_ejercicio_empresa_idempresa = this.CodEmpresa;
                mov.Datos.Cuenta_plancuentas_ejercicio_empresa_idempresa = this.CodEmpresa;
                mov.Datos.Cuenta_plancuentas_ejercicio_codejercicio = (int)this.CodEjercicio;
                mov.Datos.Asiento_ejercicio_codejercicio = (int)this.CodEjercicio;
                mov.Datos.Cuenta_plancuentas_codplancuentas = this.CodPlanCuentas;
                mov.Datos.Tipomovimiento_empresa_idempresa = this.CodEmpresa;
                movimientos.Add(mov);
            }

            Asiento asiento = new Asiento(datos);
            asiento.Movimientos = movimientos;
            if (!asiento.Balanceado)
            {
                throw new Exception("El asiento no se ha podido registrar debido a que no se encuentra balanceado.");
            }

            Datos.Phantom.Insertar(datos);
            DataSet ds = Datos.Consultar("SELECT LAST_INSERT_ID();");
            var cod = int.Parse(CapaDatos.Datos.GetValor(ds).ToString());

            try
            {
                foreach (Movimiento m in asiento.Movimientos)
                {
                    m.Datos.Asiento_idasiento = cod;
                    Datos.Phantom.Insertar(m.Datos);
                }
            }
            catch (Exception ex)
            {
                asiento.Movimientos = null;
                Datos.Phantom.Eliminar(datos);
                throw ex;
            }

            return cod;
        }

        public void CerrarSesion()
        {
            this.Usuario = "";
            this.Permisos = Permisos.PermisosGuest;
            this.CodEjercicio = 0;
            this.CodEmpresa = 0;
            this.CodPlanCuentas = 0;
            this.CodPuesto = "";
        }
    }
}
