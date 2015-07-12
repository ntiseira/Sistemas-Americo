using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("empresa_has_usuarios")]
	public class Entity_empresa_has_usuarios
	{
		private string usuarios_usuario;
		[Identificador]
		[Columna("Usuario")]
		public string Usuarios_usuario
		{
			get { return usuarios_usuario;}
			set { usuarios_usuario = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int permisos;
		public int Permisos
		{
			get { return permisos;}
			set { permisos = value;}
		}

	}
}

