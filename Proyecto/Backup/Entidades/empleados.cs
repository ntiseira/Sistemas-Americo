using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("empleados")]
	public class Entity_empleados
	{
		private int legajo;
		[Identificador(Autogenerado=true)]
		public int Legajo
		{
			get { return legajo;}
			set { legajo = value;}
		}

		private string tipoempleado;
		public string Tipoempleado
		{
			get { return tipoempleado;}
			set { tipoempleado = value;}
		}

		private string apellido;
		public string Apellido
		{
			get { return apellido;}
			set { apellido = value;}
		}

		private string nombre;
		public string Nombre
		{
			get { return nombre;}
			set { nombre = value;}
		}

		private string estadocivil;
		public string Estadocivil
		{
			get { return estadocivil;}
			set { estadocivil = value;}
		}

		private string tipodoc;
		public string Tipodoc
		{
			get { return tipodoc;}
			set { tipodoc = value;}
		}

		private long nrodocumento;
		public long Nrodocumento
		{
			get { return nrodocumento;}
			set { nrodocumento = value;}
		}

		private string nacionalidad;
		public string Nacionalidad
		{
			get { return nacionalidad;}
			set { nacionalidad = value;}
		}

		private DateTime fechanacimiento;
		public DateTime Fechanacimiento
		{
			get { return fechanacimiento;}
			set { fechanacimiento = value;}
		}

		private string domicilio;
		public string Domicilio
		{
			get { return domicilio;}
			set { domicilio = value;}
		}

		private string localidad;
		public string Localidad
		{
			get { return localidad;}
			set { localidad = value;}
		}

		private string provincia;
		public string Provincia
		{
			get { return provincia;}
			set { provincia = value;}
		}

		private string pais;
		public string Pais
		{
			get { return pais;}
			set { pais = value;}
		}

		private int codigopostal;
		public int Codigopostal
		{
			get { return codigopostal;}
			set { codigopostal = value;}
		}

		private long telefono;
		public long Telefono
		{
			get { return telefono;}
			set { telefono = value;}
		}

		private string mail;
		public string Mail
		{
			get { return mail;}
			set { mail = value;}
		}

		private int categoria;
		public int Categoria
		{
			get { return categoria;}
			set { categoria = value;}
		}

		private string datosfamiliares;
		public string Datosfamiliares
		{
			get { return datosfamiliares;}
			set { datosfamiliares = value;}
		}

		private bool activo;
		public bool Activo
		{
			get { return activo;}
			set { activo = value;}
		}

		private int obrasocial;
		public int Obrasocial
		{
			get { return obrasocial;}
			set { obrasocial = value;}
		}

		private DateTime fechaingreso;
		public DateTime Fechaingreso
		{
			get { return fechaingreso;}
			set { fechaingreso = value;}
		}

		private DateTime fechaegreso;
		public DateTime Fechaegreso
		{
			get { return fechaegreso;}
			set { fechaegreso = value;}
		}

		private int sucursal_codigosucursal;
		[Identificador]
		public int Sucursal_codigosucursal
		{
			get { return sucursal_codigosucursal;}
			set { sucursal_codigosucursal = value;}
		}

		private long sucursal_empresa_idempresa;
		[Identificador]
		public long Sucursal_empresa_idempresa
		{
			get { return sucursal_empresa_idempresa;}
			set { sucursal_empresa_idempresa = value;}
		}

	}
}

