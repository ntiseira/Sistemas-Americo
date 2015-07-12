using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("condicionesventa")]
	public class Entity_condicionesventa
	{
		private int idcondicionesventa;
		[Identificador]
		[Columna("Código")]
		public int Idcondicionesventa
		{
			get { return idcondicionesventa;}
			set { idcondicionesventa = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int tipocondicionventa_idtipocondicionventa;
		[Columna("Condición")]
		[Relacion(Destino = typeof(Entity_tipocondicionventa), CampoId = 0, CampoSecundario = 1)]
		public int Tipocondicionventa_idtipocondicionventa
		{
			get { return tipocondicionventa_idtipocondicionventa;}
			set { tipocondicionventa_idtipocondicionventa = value;}
		}

		private long tipocondicionventa_empresa_idempresa;
		[Columna(false)]
		public long Tipocondicionventa_empresa_idempresa
		{
			get { return tipocondicionventa_empresa_idempresa;}
			set { tipocondicionventa_empresa_idempresa = value;}
		}

		private int descuentosfinancieros_iddescuentosfinancieros;
		[Columna("Descuento")]
		[Relacion(Destino = typeof(Entity_descuentosfinancieros), CampoId = 0, CampoSecundario = 1, PermitirNull=true)]
		public int Descuentosfinancieros_iddescuentosfinancieros
		{
			get { return descuentosfinancieros_iddescuentosfinancieros;}
			set { descuentosfinancieros_iddescuentosfinancieros = value;}
		}

		private long descuentosfinancieros_empresa_idempresa;
		[Columna(false)]
		public long Descuentosfinancieros_empresa_idempresa
		{
			get { return descuentosfinancieros_empresa_idempresa;}
			set { descuentosfinancieros_empresa_idempresa = value;}
		}

		private string observaciones;
		public string Observaciones
		{
			get { return observaciones;}
			set { observaciones = value;}
		}

	}
}

