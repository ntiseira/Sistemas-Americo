using System;
using Ext.Net;
using IU.Contabilidad;
using WebHelper;
using System.Collections.Generic;
using VentasCuentasCobrar;
using System.Collections;
using AdministradorGeneral.Seguridad;
using CapaDatos;
using IU.Generico.Events;
using ModuloSoporte.Security;
using PhantomDb.Entidades;
using Entidades;
using System.Web.Script.Serialization;
using IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas;


namespace IU.VentasCuentasCobrar.Cobranzas
{
    public partial class CompensacionComprobante : System.Web.UI.Page
    {
        private const string var = "CompensacionComprobante.Cliente";
        
        public object SelectedItem
        {
            get { return Session["ASelit"]; }
            set { Session["ASelit"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[var] == null || Session[var].ToString().Equals(""))
            {
                if (!X.IsAjaxRequest)
                {
                    PrepararClienteCompensacion.PrepararCliente(var, "CompensacionComprobante.aspx", this);
                    Response.Redirect("PrepararClienteCompensacion.aspx");
                }
            }
            var codCliente = (int)Session[var];
           


            this.Tipo = typeof(Entity_comprobanteVenta);
            Valores = new SqlValor[] 
            { 
                new SqlValor("habilitado", 1),
                new SqlValor("empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                new SqlValor("cliente_codCliente",codCliente)
            };


            // Datagrid
            Storer st = new Storer(typeof(Entidades.Entity_comprobanteVenta));
            st.ObjectToSqlDataSource(ref SqlDataSource1);
            OnShow();
            Store1.DataBind();


           
        }








        [DirectMethod]
        protected void OnRowSelect_EventItems(object sender, DirectEventArgs e)
        {


            string json = e.ExtraParams["values"];

            Dictionary<string, string>[] lista = JSON.Deserialize<Dictionary<string, string>[]>(json);

            Entidades.Entity_comprobanteVenta comprobante = new Entity_comprobanteVenta();            

            ArrayList array = new ArrayList();
            array.Add(int.Parse(lista[0]["Numero"].ToString()));
            array.Add(lista[0]["Total"].ToString());
       

            SelectedItem = array;
        }







        #region CODIGO ABM

        private Type tipo;
        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        [DirectMethod]
        protected void Aplicar_Click(object sender, DirectEventArgs e)
        {
            ArrayList array = (ArrayList)SelectedItem;
            int nro = int.Parse(array[0].ToString());
            double total= double.Parse(array[1].ToString());
            double totalAplicar = 0;
            if (totalCompensar.Text != "")
            {
                totalAplicar = double.Parse(totalCompensar.Text);
            }
            
            AdministradorVentas.ingresarCompensacionComprobante(nro, total, totalAplicar);

            this.GridPanelCredito.Reload();
            
        }
       

      

        private Permisos permisos = null;
        public Permisos Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

        public event EventHandler AlActualizar = null;
        protected void CallAlActualizar()
        {
            if (AlActualizar != null)
            {
                AlActualizar.Invoke(this, EventArgs.Empty);
            }
        }

        //public event EventHandler AlModificar = null;
        protected void CallAlModificar(object tag, ref BeforeRecordUpdatedEventArgs e)
        {
            if (AlModificar != null)
            {
                var ev = new EventUpdateAbm(tag, ref e);
                AlModificar.Invoke(this, ev);
            }
        }

        public event EventHandler<EventInsertAbm> AlInsertar = null;
        public event EventHandler<EventUpdateAbm> AlModificar = null;

        /// <summary>
        /// Ejecuta el evento "AlInsertar".
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="e"></param>
        protected void CallAlInsertar(object tag, ref BeforeRecordInsertedEventArgs e)
        {
            if (AlInsertar != null)
            {
                EventInsertAbm ev = new EventInsertAbm(tag, ref e);
                AlInsertar.Invoke(this, ev);

            }
        }

        private SqlValor[] valores;
        /// <summary>
        /// Preestablece ciertos valores, que son de utilidad para las consultas.
        /// </summary>
        /// <example>
        /// -------------------
        /// Tabla: TipoAsiento
        /// -------------------
        /// Descripcion (Key)
        /// Habilitado
        /// CodEmpresa (Key)
        /// -------------------
        /// 
        /// Necesito trabajar sobre todos los tipos de asientos, para una determinada
        /// empresa.
        /// 
        /// Entonces, hago lo siguiente:
        /// 
        /// <code>
        /// this.ControlAbm1.Tipo = typeof(Siscont.Contabilidad.TipoAsiento);
        /// // 2 es el tipo de empresa.
        /// this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("CodEmpresa", 2) };
        /// this.ControlAbm1.OnShow();
        /// </code>
        /// </example>
        public SqlValor[] Valores
        {
            get { return valores; }
            set { valores = value; }
        }

        private SqlValor[] valoresCombo;
        /// <summary>
        /// SqlValor aplicado a los combo boxes.
        /// </summary>
        public SqlValor[] ValoresCombo
        {
            get { return valoresCombo; }
            set { valoresCombo = value; }
        }


        #region Atributos de bases de datos

        private String stringConnection = "";
        public String StringConnection
        {
            get { return stringConnection; }
            set { stringConnection = value; }
        }

        private String select = "";
        public String Select
        {
            get { return select; }
            set { select = value; }
        }

        private String insert = "";
        public String Insert
        {
            get { return insert; }
            set { insert = value; }
        }

        private String update = "";
        public String Update
        {
            get { return update; }
            set { update = value; }
        }

        private String delete = "";
        public String Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        #endregion

        protected void DeleteRow()
        {
            try
            {
                string json = Session["json"].ToString();
                Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);

                Storer st = new Storer(Tipo);
                st.Valores = Valores;
                string consulta = st.MakeDeleteRow(companies);
                Datos.ConsultarEx(consulta);
            }
            catch { }
            //Store1.WarningOnDirty = false;
           
            //Store1.WarningOnDirty = true;
        }

        protected void btnDelete_OnClick(object sender, DirectEventArgs e)
        {
            try
            {
                Session["json"] = e.ExtraParams["Values"];

                if ((bool)Session["Respuesta"] == false)
                {
                    DoConfirm();
                }
                else
                {
                    DeleteRow();
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

       


        public void OnShow()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(Tipo);
                st.Valores = Valores;
                st.ValoresCombo = ValoresCombo;

              
              //  if (Select.Equals(""))
                    Select = st.GetSelect();
        

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;              
                this.SqlDataSource1.SelectCommand = Select;
         

                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref Store1);
               // st.ObjectToGridPanel(ref GridPanelDebito);

              /*  // Permisos de la tabla
                if (Permisos == null)
                    Permisos = ContabilidadGlobal.Admin.Permisos;

                if (!Permisos.Alta)
                {
                    this.btnInsert.Enabled = false;
                    this.btnInsert.Hide();
                    if (!Permisos.Modif)
                    {
                        this.btnSave.Enabled = false;
                        this.btnSave.Hide();
                    }
                }
                if (!Permisos.Baja)
                {
                    this.btnDelete.Enabled = false;
                    this.btnDelete.Hide();
                }
                */
              
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        public void OnShowCredito()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(typeof(Entidades.Entity_ComprobanteCompra));
                st.Valores = Valores;
                st.ValoresCombo = ValoresCombo;

                //  if (Select.Equals(""))
                Select = st.GetSelect();

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;
                this.SqlDataSource1.SelectCommand = Select;

                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref Store1);
          //      st.ObjectToGridPanel(ref GridPanelCredito);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }




        


        #region Mensaje de confirmación
        [DirectMethod]
        public void DoConfirm()
        {
            // Configure individualock Buttons using a ButtonsConfig...
            X.Msg.Confirm(
                "Eliminar elemento",
                "Usted está apunto de eliminar un elemento. Tenga en cuenta que el elemento será eliminado de forma permanente. ¿Desea continuar?",
                new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "DoYes()",
                        Text = "Si"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "DoNo()",
                        Text = "No"
                    }
                }).Show();

        }

        [DirectMethod]
        public void DoYes()
        {
            Session["Respuesta"] = true;
            DeleteRow();
        }

        [DirectMethod]
        public void DoNo()
        {
            Session["Respuesta"] = false;
        }
        #endregion

        /// <summary>
        /// Ejecuta el evento antes de insertar un registro en la base de datos.
        /// </summary>
        /// <param name="e"></param>
        protected void AlInsertarRecord(ref BeforeRecordInsertedEventArgs e)
        {
            // Seguridad
            IDictionary test = e.NewValues;
            var companies = new Dictionary<string, string>[1];
            companies[0] = new Dictionary<string, string>();

            try
            {
                foreach (object o in test.Keys)
                {
                    var value = test[o].ToString();
                    SQLInjection.AplicarSeguridad(ref value);
                    if (SQLInjection.IsSqlSentence(value))
                    {
                        throw new Exception("Uno de los valores ingresados no cumple con las reglas de seguridad del sistema. La operación será cancelada.");
                    }
                    else
                    {
                        companies[0].Add(o.ToString(), value);
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error de seguridad");
                e.Cancel = true;
            }

            // Evento al insertar
            if (AlInsertar != null)
            {
                object obj;
                try
                {
                    Storer st = new Storer(Tipo);
                    st.Valores = Valores;

                    obj = st.MakeObjectFromRow(companies);
                }
                catch (Exception ex)
                {
                    obj = null;
                    UIHelper.MostrarExcepcionSimple(ex, "Error");
                }
                CallAlInsertar(obj, ref e);
            }
        }


        [DirectMethod]
        public void ExcepcionValidacionDatos()
        {
            try
            {
                throw new Exception("Error en ingreso de datos, ingrese valores válidos en los datos");
            }
            catch (Exception e)
            {
                Ext.Net.ResourceManager.AjaxSuccess = false;
                Ext.Net.ResourceManager.AjaxErrorMessage = e.Message;
            }
        }


        /// <summary>
        /// Ejecuta el evento antes de modificar un registro en la base de datos.
        /// </summary>
        /// <param name="e"></param>
        protected void AlModificarRecord(ref BeforeRecordUpdatedEventArgs e)
        {
            // Seguridad
            IDictionary test = e.NewValues;
            var companies = new Dictionary<string, string>[1];
            companies[0] = new Dictionary<string, string>();

            try
            {
                foreach (object o in test.Keys)
                {
                    var value = test[o].ToString();
                    SQLInjection.AplicarSeguridad(ref value);
                    if (SQLInjection.IsSqlSentence(value))
                    {
                        throw new Exception("Uno de los valores ingresados no cumple con las reglas de seguridad del sistema. La operación será cancelada.");
                    }
                    else
                    {
                        companies[0].Add(o.ToString(), value);
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error de seguridad");
                e.Cancel = true;
            }

            // Evento al modificar
            if (AlModificar != null)
            {
                object obj;
                try
                {
                    Storer st = new Storer(Tipo);
                    st.Valores = Valores;

                    obj = st.MakeObjectFromRow(companies);
                }
                catch (Exception ex)
                {
                    obj = null;
                    UIHelper.MostrarExcepcionSimple(ex, "Error");
                }
                CallAlModificar(obj, ref e);
            }
        }

        #endregion


     

    }
}
