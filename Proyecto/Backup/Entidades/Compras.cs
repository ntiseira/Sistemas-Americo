using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Compras")]
	public class Entity_Compras
	{
		private int cod_compra;
		[Identificador(Modificable=false,Autogenerado=true)]
		[Columna(Titulo="Código")]
		public int Cod_compra
		{
			get { return cod_compra;}
			set { cod_compra = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private double total;
		public double Total
		{
			get { return total;}
			set { total = value;}
		}

		private int proveedores_cod_proveedor;
		[Identificador]
		[Columna(Titulo = "Proveedor")]
		[Relacion(Destino = typeof(Entidades.Entity_proveedor), CampoId = 0, CampoSecundario = 1)]
		public int Proveedores_cod_proveedor
		{
			get { return proveedores_cod_proveedor;}
			set { proveedores_cod_proveedor = value;}
		}

		private long proveedores_empresa_idempresa;
		[Identificador]
		[Columna(Titulo = "Empresa", Visible=false)]
		public long Proveedores_empresa_idempresa
		{
			get { return proveedores_empresa_idempresa;}
			set { proveedores_empresa_idempresa = value;}
		}

	}
}

