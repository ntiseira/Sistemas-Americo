using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("usuarios_has_sucursal")]
	public class Entity_usuarios_has_sucursal
	{
		private string usuarios_usuario;
		[Identificador]
		[Columna("Usuario")]
		[Relacion(Destino = typeof(Entity_empresa_has_usuarios), CampoId = 0, CampoSecundario = 0)]
		public string Usuarios_usuario
		{
			get { return usuarios_usuario;}
			set { usuarios_usuario = value;}
		}

		private int sucursal_codigosucursal;
		[Identificador]
		[Columna("Sucursal")]
		[Relacion(Destino = typeof(Entity_sucursal), CampoId = 0, CampoSecundario = 1)]
		public int Sucursal_codigosucursal
		{
			get { return sucursal_codigosucursal;}
			set { sucursal_codigosucursal = value;}
		}

		private long sucursal_empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Sucursal_empresa_idempresa
		{
			get { return sucursal_empresa_idempresa;}
			set { sucursal_empresa_idempresa = value;}
		}

		private int permisos;
		public int Permisos
		{
			get { return permisos;}
			set { permisos = value;}
		}

	}
}

