using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("LineaCompras")]
	public class Entity_LineaCompras
	{
		private int cod_lineacompras;
		[Identificador(Modificable=false,Autogenerado=true)]
		[Columna(Titulo="Código")]
		public int Cod_lineacompras
		{
			get { return cod_lineacompras;}
			set { cod_lineacompras = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private double importe;
		public double Importe
		{
			get { return importe;}
			set { importe = value;}
		}

		private int cantidad;
		public int Cantidad
		{
			get { return cantidad;}
			set { cantidad = value;}
		}

		private int compras_cod_compra;
		[Identificador]
		[Columna(Titulo = "Código de compra",Visible=false)]
		public int Compras_cod_compra
		{
			get { return compras_cod_compra;}
			set { compras_cod_compra = value;}
		}

		private int compras_proveedores_cod_proveedor;
		[Identificador]
		[Columna(Titulo = "Proveedor", Visible = false)]
		[Relacion(Destino = typeof(Entidades.Entity_proveedor), CampoId = 0, CampoSecundario = 1)]
		public int Compras_proveedores_cod_proveedor
		{
			get { return compras_proveedores_cod_proveedor;}
			set { compras_proveedores_cod_proveedor = value;}
		}

		private long compras_proveedores_empresa_idempresa;
		[Identificador(Modificable=false)]
		[Columna(Titulo="Empresa",Visible=false)]
		public long Compras_proveedores_empresa_idempresa
		{
			get { return compras_proveedores_empresa_idempresa;}
			set { compras_proveedores_empresa_idempresa = value;}
		}

	}
}

