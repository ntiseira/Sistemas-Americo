using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("sucursal")]
	public class Entity_sucursal
	{
		private int codigosucursal;
		[Identificador]
		[Columna("Código")]
		public int Codigosucursal
		{
			get { return codigosucursal;}
			set { codigosucursal = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool casacentral;
		[Columna("Casa central")]
		public bool Casacentral
		{
			get { return casacentral;}
			set { casacentral = value;}
		}

		private string cp;
		public string Cp
		{
			get { return cp;}
			set { cp = value;}
		}

		private long cuit;
		public long Cuit
		{
			get { return cuit;}
			set { cuit = value;}
		}

		private string departamento;
		public string Departamento
		{
			get { return departamento;}
			set { departamento = value;}
		}

		private string telefono;
		[Columna("Teléfono")]
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

		private string localidad;
		public string Localidad
		{
			get { return localidad;}
			set { localidad = value;}
		}

		private string direccion;
		[Columna("Dirección")]
		public string Direccion
		{
			get { return direccion;}
			set { direccion = value;}
		}

		private int num;
		[Columna("Número")]
		public int Num
		{
			get { return num;}
			set { num = value;}
		}

		private int piso;
		public int Piso
		{
			get { return piso;}
			set { piso = value;}
		}

		private bool habilitada;
		public bool Habilitada
		{
			get { return habilitada;}
			set { habilitada = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int provincia_codprov;
		[Atributo]
		[Columna("Código de provincia")]
		[Relacion(Destino = typeof(Entity_provincia), CampoId = 0, CampoSecundario = 1)]
		public int Provincia_codprov
		{
			get { return provincia_codprov;}
			set { provincia_codprov = value;}
		}

	}
}

