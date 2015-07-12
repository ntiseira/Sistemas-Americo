using System;
using CapaDatos;
using Ext.Net;
using Entidades;
using System.Collections.Generic;

namespace IU.Contabilidad.PlanCuentas
{
    public partial class ArbolPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtengo el listado de cuentas del plan actual
            var cuentas = Datos.Phantom.Listar(typeof(Entity_cuenta), 
                string.Format(
                    "planCuentas_codPlanCuentas = {0} AND planCuentas_ejercicio_codejercicio = {1} AND planCuentas_ejercicio_empresa_idempresa = {2}"
                    , ContabilidadGlobal.Admin.CodPlanCuentas, ContabilidadGlobal.Admin.CodEjercicio, ContabilidadGlobal.Admin.CodEmpresa));

            // Genero los nodos del árbol
            List<TreeNode> nodos = new List<TreeNode>();
            foreach(Entity_cuenta ec in cuentas)
            {
                var nodo = new TreeNode(ec.Idcuenta, ec.Imputable ? Icon.Folder : Icon.Note);
                nodo.Leaf = ec.Imputable;
                nodos.Add(nodo);
            }
        }
    }
}
