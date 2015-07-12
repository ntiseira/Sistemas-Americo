using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebHelper;
using Ext.Net;
using System.Collections;
using ModuloSoporte.Security;
using AdministradorGeneral.Seguridad;
using IU.Generico.Events;
using Entidades;
using CapaDatos;
using IU.Contabilidad;

namespace IU.VentasCuentasCobrar
{
    public partial class ConceptoFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["Respuesta"] = false; //[TODO: Hacer mensaje de confirmación que se muestra una sola vez, al querer eliminar algo en control ABM]
            this.tipo = typeof(Entidades.Entity_concepto);
            this.Titulo = "Conceptos de facturacion";
            
            // Datagrid
            Storer st = new Storer(typeof(Entidades.Entity_concepto));
            st.ObjectToSqlDataSource(ref SqlDataSource1);
            OnShow();
            Store1.DataBind();
            
            #warning terminar tema de los combobox
            
            //ComboTasaIva
            Storer sttasaiva = new Storer(typeof(Entity_tasaiva));
            OnshowTasaIva(sttasaiva);
            
            //ComboMonedas
            Storer stMonedas = new Storer(typeof(Entity_moneda));
            OnshowMoneda(stMonedas);
        }



#warning arreglar qu calcule solo el tema del precio total , ver como implemente cookies en ingresar comprobante
        public object SelectedTasa
        {
            get { return Session["DescuentoFinanciero"]; }
            set { Session["DescuentoFinanciero"] = value; }
        }



        protected void OnRowSelect(object sender, DirectEventArgs e)
        {

            string json = e.ExtraParams["Values"];
        }



        #region COMBOBOX
        
        private void OnshowMoneda(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;

            Select = storeCombo.GetSelect();


            this.SqlDataSource3.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource3.ConnectionString = StringConnection;
            this.SqlDataSource3.SelectCommand = Select;

        }

        private void OnshowTasaIva(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;

            Select = storeCombo.GetSelect();


            this.SqlDataSource2.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource2.ConnectionString = StringConnection;
            this.SqlDataSource2.SelectCommand = Select;

        }



        #endregion


        #region ABM


        private Type tipo;
        private Permisos permisos = null;       

        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

             public String Titulo
        {
            get
            {
                return GridPanel1.Title;
            }

            set
            {
                GridPanel1.Title = value;
                LabelTitulo.Text = value;
            }
        }

        public String Descripcion
        {
            get
            {
                return LabelDescrip.Text;
            }

            set
            {
                LabelDescrip.Text = value;
            }
        }

        public Permisos Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

        #endregion

     
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




        private Entity_concepto selectedItem = null;
        public Entity_concepto SelectedItem
        {
            get { return selectedItem; }
            protected set { selectedItem = value; }
        }
    
        [DirectMethod]
        public double DevolverPrecio()
        {
        #warning arreglar EL BUG DE JAVASCRIPT CUANDO QUIERE MODIFICAR EL PRECIO TOTAL , PARA QUE LO CALCULE SOLO
            Entidades.Entity_concepto concepto = SelectedItem;

            double tasa = concepto.Tasaiva;
            double precioNeto = concepto.PrecioNeto;
            double recargo = (precioNeto * tasa) / 100;


            return precioNeto + recargo;
        }



        [DirectMethod]
        protected void OnRowSelect_Event(object sender, DirectEventArgs e)
        {
            SelectedItem = null;
            try
            {
                string json = e.ExtraParams["Values"];
              //  Dictionary<string, string>[] rows = JSON.Deserialize<Dictionary<string, string>[]>(json);
              
                //var lista = jss.Deserialize<Dictionary<string, string>>(json);

                Dictionary<string, string>[] lista = JSON.Deserialize<Dictionary<string, string>[]>(json);

                Entidades.Entity_concepto concepto = new Entity_concepto();
           
                    concepto.Codconcepto = int.Parse(lista[0]["Codconcepto"]);
                    concepto.Descripcion = lista[0]["Descripcion"];
                    concepto.Clase = lista[0]["Clase"];
                    concepto.Observaciones = lista[0]["Observaciones"];
                    concepto.Tipo = lista[0]["Tipo"];
                    concepto.Tasaiva = double.Parse(lista[0]["Tasaiva"]);
                    concepto.PrecioNeto = double.Parse(lista[0]["PrecioNeto"]);
                    concepto.PrecioFinal = double.Parse(lista[0]["PrecioFinal"]);
                    //concepto.Empresa_idempresa = int.Parse(lista[0]["Empresa_idempresa"]);
                    //concepto.Moneda_idmoneda = int.Parse(lista[0]["Moneda_idmoneda"]);
                        

                SelectedItem = concepto;
              
            }
            catch { }

            // TODO
        }


        private SqlValor[] valores;
        public SqlValor[] Valores
        {
            get { return valores; }
            set { valores = value; }
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

            bool respu = (bool)Session["Respuesta"];
            if (respu == true)
            {
                string json = Session["json"].ToString();
                Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);

                Storer st = new Storer(Tipo);             
                string consulta = st.MakeDeleteRow(companies);
                Datos.ConsultarEx(consulta);
                GridPanel1.Reload();
            }
        }

        #region Botones




        protected void btnDelete_OnClick(object sender, DirectEventArgs e)
        {
            try
            {
                Session["json"] = e.ExtraParams["Values"];
                DoConfirm();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        
        #endregion

        public void OnShow()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(Tipo);       

                if (Insert.Equals(""))
                    Insert = st.GetInsert();
                if (Select.Equals(""))
                    Select = st.GetSelect();
                if (Update.Equals(""))
                    Update = st.GetUpdate();
                if (Delete.Equals(""))
                    Delete = st.GetDelete();

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;
                this.SqlDataSource1.InsertCommand = Insert;
                this.SqlDataSource1.SelectCommand = Select;
                this.SqlDataSource1.UpdateCommand = Update;
                this.SqlDataSource1.DeleteCommand = Delete;

                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref Store1);
                      
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        public void Reload()
        {
            GridPanel1.Reload();
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
                       Handler = "prueba.DoYes()",
                       Text = "Si"
                   },
                   No = new MessageBoxButtonConfig
                   {

                       Handler = "prueba.DoNo()",
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
            DeleteRow();
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

 







    }
}