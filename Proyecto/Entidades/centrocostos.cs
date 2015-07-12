using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("centrocostos")]
	public class Entity_centrocostos
	{
		private int idcentrocostos;
		[Identificador]
		[Columna("Código")]
		public int Idcentrocostos
		{
			get { return idcentrocostos;}
			set { idcentrocostos = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
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

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int area_idarea;
		[Columna("Área")]
		[Relacion(Destino=typeof(Entity_area), CampoId=0, CampoSecundario=1)]
		public int Area_idarea
		{
			get { return area_idarea;}
			set { area_idarea = value;}
		}

		private long area_empresa_idempresa;
		[Columna(Visible=false)]
		public long Area_empresa_idempresa
		{
			get { return area_empresa_idempresa;}
			set { area_empresa_idempresa = value;}
		}

		private int departamento_iddepartamento;
		[Columna("Departamento")]
		[Relacion(Destino = typeof(Entity_departamento), CampoId = 0, CampoSecundario = 1)]
		public int Departamento_iddepartamento
		{
			get { return departamento_iddepartamento;}
			set { departamento_iddepartamento = value;}
		}

		private long departamento_empresa_idempresa;
		[Columna(Visible = false)]
		public long Departamento_empresa_idempresa
		{
			get { return departamento_empresa_idempresa;}
			set { departamento_empresa_idempresa = value;}
		}

	}
}

