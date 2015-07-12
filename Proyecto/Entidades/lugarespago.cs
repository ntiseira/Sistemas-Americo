using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("lugarespago")]
	public class Entity_lugarespago
	{
		private long codigo;
		[Identificador(Autogenerado=true)]
		public long Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string calle;
		public string Calle
		{
			get { return calle;}
			set { calle = value;}
		}

		private int numerocalle;
		public int Numerocalle
		{
			get { return numerocalle;}
			set { numerocalle = value;}
		}

		private int piso;
		public int Piso
		{
			get { return piso;}
			set { piso = value;}
		}

		private int departamento;
		public int Departamento
		{
			get { return departamento;}
			set { departamento = value;}
		}

		private string localidad;
		public string Localidad
		{
			get { return localidad;}
			set { localidad = value;}
		}

		private int codigopostal;
		public int Codigopostal
		{
			get { return codigopostal;}
			set { codigopostal = value;}
		}

		private string provincia;
		public string Provincia
		{
			get { return provincia;}
			set { provincia = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private bool domicilioexplotacion;
		public bool Domicilioexplotacion
		{
			get { return domicilioexplotacion;}
			set { domicilioexplotacion = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

