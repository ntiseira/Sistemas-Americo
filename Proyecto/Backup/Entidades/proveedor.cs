using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("proveedor")]
	public class Entity_proveedor
	{
		private int idproveedor;
		[Identificador]
		[Columna("Código")]
		public int Idproveedor
		{
			get { return idproveedor;}
			set { idproveedor = value;}
		}

		private string razonsocial;
		[Columna("Razón social")]
		public string Razonsocial
		{
			get { return razonsocial;}
			set { razonsocial = value;}
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

		private string telefono;
		public string Telefono
		{
			get { return telefono;}
			set { telefono = value;}
		}

		private string codpostal;
		public string Codpostal
		{
			get { return codpostal;}
			set { codpostal = value;}
		}

		private string fax;
		public string Fax
		{
			get { return fax;}
			set { fax = value;}
		}

		private string email;
		public string Email
		{
			get { return email;}
			set { email = value;}
		}

		private int provincia_codprov;
		[Columna("Provincia")]
		[Relacion(Destino=typeof(Entity_provincia), CampoId=0, CampoSecundario=1)]
		public int Provincia_codprov
		{
			get { return provincia_codprov;}
			set { provincia_codprov = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Titulo="Empresa",Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int tipoproveedor_idtipoproveedor;
		[Columna("Tipo de proveedor")]
		[Relacion(Destino = typeof(Entity_tipoproveedor), CampoId = 0, CampoSecundario = 1)]
		public int Tipoproveedor_idtipoproveedor
		{
			get { return tipoproveedor_idtipoproveedor;}
			set { tipoproveedor_idtipoproveedor = value;}
		}

		private long tipoproveedor_empresa_idempresa;
		[Columna(Titulo = "Empresa (prov)", Visible = false)]
		public long Tipoproveedor_empresa_idempresa
		{
			get { return tipoproveedor_empresa_idempresa;}
			set { tipoproveedor_empresa_idempresa = value;}
		}

	}
}

