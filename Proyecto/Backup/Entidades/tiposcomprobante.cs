using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiposcomprobante")]
	public class Entity_tiposcomprobante
	{
		private string idtipocomprobante;
		[Identificador]
	//	[Columna(Titulo="Código")]
		public string Idtipocomprobante
		{
			get { return idtipocomprobante;}
			set { idtipocomprobante = value;}
		}

		private string descrip;
	//	[Columna(Titulo = "Descripción")]
		public string Descrip
		{
			get { return descrip;}
			set { descrip = value;}
		}

		private string clase;
		public string Clase
		{
			get { return clase;}
			set { clase = value;}
		}

		private string descripcionimpresion;
		[Columna(Titulo = "Descripción Impresión")]
		public string Descripcionimpresion
		{
			get { return descripcionimpresion;}
			set { descripcionimpresion = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Titulo = "Empresa",Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private string codlibroiva;
		[Columna(Titulo = "Código Libro Iva", Visible = false)]
		public string Codlibroiva
		{
			get { return codlibroiva;}
			set { codlibroiva = value;}
		}

		private bool respinscripto;
		[Columna(Titulo = "Es Resp. Ins.", Visible = false)]
		public bool Respinscripto
		{
			get { return respinscripto;}
			set { respinscripto = value;}
		}

		private bool respnoinscripto;
		[Columna(Titulo = "Es No Resp. Ins.", Visible = false)]
		public bool Respnoinscripto
		{
			get { return respnoinscripto;}
			set { respnoinscripto = value;}
		}

		private bool consumidorfinal;
		[Columna(Titulo = "Es Consumidor Final", Visible = false)]
		public bool Consumidorfinal
		{
			get { return consumidorfinal;}
			set { consumidorfinal = value;}
		}

		private bool noresponsable;
		[Columna(Titulo = "Es No Responsable", Visible = false)]
		public bool Noresponsable
		{
			get { return noresponsable;}
			set { noresponsable = value;}
		}

		private bool exento;
		public bool Exento
		{
			get { return exento;}
			set { exento = value;}
		}

		private bool monotributista;
		public bool Monotributista
		{
			get { return monotributista;}
			set { monotributista = value;}
		}

		private bool sujetonocateg;
		[Columna(Titulo = "Es Sujeto no Categ.", Visible = false)]
		public bool Sujetonocateg
		{
			get { return sujetonocateg;}
			set { sujetonocateg = value;}
		}

		private bool nodependesitiva;
		[Columna(Titulo = "No depende sit. IVA", Visible = false)]
		public bool Nodependesitiva
		{
			get { return nodependesitiva;}
			set { nodependesitiva = value;}
		}

	}
}

