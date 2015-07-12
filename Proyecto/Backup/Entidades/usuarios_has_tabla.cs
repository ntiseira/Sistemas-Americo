using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("usuarios_has_tabla")]
	public class Entity_usuarios_has_tabla
	{
		private string usuarios_usuario;
		[Identificador]
		public string Usuarios_usuario
		{
			get { return usuarios_usuario;}
			set { usuarios_usuario = value;}
		}

		private int tabla_idtabla;
		[Identificador]
		public int Tabla_idtabla
		{
			get { return tabla_idtabla;}
			set { tabla_idtabla = value;}
		}

		private int permisos;
		public int Permisos
		{
			get { return permisos;}
			set { permisos = value;}
		}

	}
}

