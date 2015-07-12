using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("puntoventa")]
	public class Entity_puntoventa
	{
		private int codpuntoventa;
		[Identificador]
		public int Codpuntoventa
		{
			get { return codpuntoventa;}
			set { codpuntoventa = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private string direccion;
		public string Direccion
		{
			get { return direccion;}
			set { direccion = value;}
		}

		private string localidad;
		public string Localidad
		{
			get { return localidad;}
			set { localidad = value;}
		}

		private string codigopostal;
		public string Codigopostal
		{
			get { return codigopostal;}
			set { codigopostal = value;}
		}

		private string telefono;
		public string Telefono
		{
			get { return telefono;}
			set { telefono = value;}
		}

		private string fax;
		public string Fax
		{
			get { return fax;}
			set { fax = value;}
		}

		private DateTime fechainicioactividades;
		public DateTime Fechainicioactividades
		{
			get { return fechainicioactividades;}
			set { fechainicioactividades = value;}
		}

		private int provincia_codprov;
		public int Provincia_codprov
		{
			get { return provincia_codprov;}
			set { provincia_codprov = value;}
		}

	}
}

