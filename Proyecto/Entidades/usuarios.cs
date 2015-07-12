using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("usuarios")]
	public class Entity_usuarios
	{
       
		private string usuario;
		[Identificador]
		public string Usuario
		{
			get { return usuario;}
			set { usuario = value;}
		}

		private string password;
		public string Password
		{
			get { return password;}
			set { password = value;}
		}

		private string tipousuario;
		public string Tipousuario
		{
			get { return tipousuario;}
			set { tipousuario = value;}
		}

	}
}

