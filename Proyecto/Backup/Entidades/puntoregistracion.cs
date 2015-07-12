using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("puntoregistracion")]
	public class Entity_puntoregistracion
	{
		private int codigopuntoregistracion;
		[Identificador]
		public int Codigopuntoregistracion
		{
			get { return codigopuntoregistracion;}
			set { codigopuntoregistracion = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private int provincia;
		public int Provincia
		{
			get { return provincia;}
			set { provincia = value;}
		}

		private DateTime fechacierreivaventas;
		public DateTime Fechacierreivaventas
		{
			get { return fechacierreivaventas;}
			set { fechacierreivaventas = value;}
		}

		private DateTime fechacierreivacompras;
		public DateTime Fechacierreivacompras
		{
			get { return fechacierreivacompras;}
			set { fechacierreivacompras = value;}
		}

		private int ulthojaivaventas;
		public int Ulthojaivaventas
		{
			get { return ulthojaivaventas;}
			set { ulthojaivaventas = value;}
		}

		private int ulthojaivacompras;
		public int Ulthojaivacompras
		{
			get { return ulthojaivacompras;}
			set { ulthojaivacompras = value;}
		}

		private int puntoventa;
		public int Puntoventa
		{
			get { return puntoventa;}
			set { puntoventa = value;}
		}

		private int puntoventa_codpuntoventa;
		public int Puntoventa_codpuntoventa
		{
			get { return puntoventa_codpuntoventa;}
			set { puntoventa_codpuntoventa = value;}
		}

	}
}

