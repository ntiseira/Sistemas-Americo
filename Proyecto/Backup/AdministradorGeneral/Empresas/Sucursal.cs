using System;
using AdministradorGeneral.Tablas;
using PhantomDb.Entidades;

namespace AdministradorGeneral.Empresas 
{
    public class Sucursal
    {
        private long codSucursal;
        [Identificador]
        public long CodSucursal
        {
            get { return codSucursal; }
            set { codSucursal = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool casaCentral;
        /// <summary>
        /// Atributo que indica si la empresa será una casa central. En caso de ser marcada,
        /// habilita a la empresa a tener sucursales.
        /// </summary>
        public bool CasaCentral
        {
            get { return casaCentral; }
            set { casaCentral = value; }
        }

        private String cp;
        /// <summary>
        /// Código postal. Acepta valores alfanuméricos por si se desea utilizar el nuevo
        /// formato de códigos postales.
        /// </summary>
        public String Cp
        {
            get { return cp; }
            set { cp = value; }
        }

        private long cuit;
        /// <summary>
        /// C.U.I.T. El sistema deberá validarlo y avisar en caso de que sea incorrecto.
        /// </summary>
        public long Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        private String dpto;
        /// <summary>
        /// Departamento.
        /// </summary>
        public String Dpto
        {
            get { return dpto; }
            set { dpto = value; }
        }

        private String telefono;
        /// <summary>
        /// Número de teléfono. Acepta valores alfanuméricos, para permitir poder utilizar paréntesis,
        /// y hacer aclaraciones.
        /// </summary>
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string fax;
        /// <summary>
        /// Fax.
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private Provincia provincia;
        /// <summary>
        /// 
        /// </summary>
        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private String localidad;
        /// <summary>
        /// localidad, barrio, ciudad, paraje, etc., correspondiente al domicilio.
        /// </summary>
        public String Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        private String direccion;
        /// <summary>
        /// Dirección.
        /// </summary>
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private int num;
        /// <summary>
        /// 
        /// </summary>
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        private int piso;
        /// <summary>
        /// 
        /// </summary>
        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        private bool habilitada;
        /// <summary>
        /// 
        /// </summary>
        public bool Habilitada
        {
            get { return habilitada; }
            set { habilitada = value; }
        }

        public Sucursal(){

		}

	}//end Sucursal

}//end namespace Empresas