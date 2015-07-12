using Entidades;

namespace ComprasCuentasPagar
{
    public class AdministradorCompras
    {
        /// <summary>
        /// Crea los datos adicionales de un proveedor.
        /// </summary>
        /// <param name="codcli"></param>
        public static void CrearDatosSiNoExisten(int codProveedor)
        {
            var phantom = CapaDatos.Datos.Phantom;
            var cliente = (Entity_proveedor)phantom.Cargar(
                typeof(Entity_proveedor),
                string.Format("idproveedor={0} AND empresa_idempresa={1}", codProveedor, ModuloSoporte.Global.CodEmpresa));

            var otrosdatos = new Entity_proveedoresotrosdatos
            {
                Proveedor_idproveedor = codProveedor,
                Proveedor_empresa_idempresa = cliente.Empresa_idempresa
            };

            if (!phantom.Existe(otrosdatos))
            {
                phantom.Insertar(otrosdatos);
            }

            var datosimpositivos = new Entity_proveedoresdatosimposit
            {
                Proveedor_idproveedor = codProveedor,
                Proveedor_empresa_idempresa = cliente.Empresa_idempresa,
                Situacioniva = Documento.DefaultSituacionIva
            };

            if (!phantom.Existe(datosimpositivos))
            {
                phantom.Insertar(datosimpositivos);
            }

        }

    }
}
