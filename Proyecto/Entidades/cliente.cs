using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("cliente")]
	public class Entity_cliente
	{
		private int codcliente;
		[Identificador(Autogenerado=true)]
		[Columna(Titulo="Código", Visible=false)]
		public int Codcliente
		{
			get { return codcliente;}
			set { codcliente = value;}
		}

		private string razonsocial;
		[Columna(Titulo = "Razón social")]
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
		[Columna(Titulo = "Dirección")]
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
         [Atributo(EsNumerico = true)]
		[Columna(Titulo = "Teléfono")]
		public string Telefono
		{
			get { return telefono;}
			set { telefono = value;}
		}

		private string codpostal;
         [Atributo(EsNumerico = true)]
		[Columna(Titulo = "Código postal")]
		public string Codpostal
		{
			get { return codpostal;}
			set { codpostal = value;}
		}

		private string fax;
         [Atributo(EsNumerico = true)]
		public string Fax
		{
			get { return fax;}
			set { fax = value;}
		}

          
		private string email;
    
		[Columna(Titulo = "E-mail")]
		public string Email
		{
			get { return email;}
			set { email = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int tipocliente_idtipocliente;
		[Columna("Tipo de cliente")] 
        [Relacion(Destino = typeof(Entity_tipocliente), CampoId = 0, CampoSecundario = 1)]
		public int Tipocliente_idtipocliente
		{
			get { return tipocliente_idtipocliente;}
			set { tipocliente_idtipocliente = value;}
		}

		private long tipocliente_empresa_idempresa;
		[Columna(false)]
		public long Tipocliente_empresa_idempresa
		{
			get { return tipocliente_empresa_idempresa;}
			set { tipocliente_empresa_idempresa = value;}
		}

        private int provincia_id;
        [Columna("Provincia")] 
        public int Provincia_id
        {
            get { return provincia_id; }
            set { provincia_id = value; }
        }


	}//clase
}//namespace

