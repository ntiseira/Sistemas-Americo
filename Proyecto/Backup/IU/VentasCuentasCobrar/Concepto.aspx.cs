using System;
using AdministradorGeneral.Empresas;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ext.Net;
using IU.Contabilidad;
using IU.Generico.Events;
using ModuloSoporte.Security;
using PhantomDb.Entidades;
using WebHelper;
using AdministradorGeneral.Seguridad;
using System.Collections.Generic;
using CapaDatos;
using ModuloSoporte;
using Ext.Net;
using Entidades;



namespace IU.VentasCuentasCobrar
{
    public partial class Concepto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["Respuesta"] = false; //[TODO: Hacer mensaje de confirmación que se muestra una sola vez, al querer eliminar algo en control ABM]
                this.tipo = typeof(Entidades.Entity_concepto);
                this.Titulo = "Conceptos de facturacion";

                                

                // Datagrid
                Storer st = new Storer(typeof(Entidades.Entity_concepto));
                st.ObjectToSqlDataSource(ref SqlDataSource1);
                OnShow();
                Store1.DataBind();
              

                //ComboBox
                 
                tipoCombo = typeof(Entidades.Entity_tasaiva);
                ComboBoxObjetos.Width = ComboBoxObjetos.Width;
                ValoresCombo = new SqlValor[] 
            { 
                new SqlValor("empresa_idempresa", ModuloSoporte.Global.CodEmpresa)
            };
                OnShowComboBox();

            
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

    

        #region ComboBox

        #region Atributos objeto

        private Type tipoCombo;
        public Type TipoCombo
        {
            get
            {
                return tipoCombo;
            }
            set { tipoCombo = value; }
        } 
        

        private SqlValor[] valoresCombo;
        /// <summary>
        /// SqlValor aplicado al combo box.
        /// </summary>
        public SqlValor[] ValoresCombo
        {
            get { return valoresCombo; }
            set { valoresCombo = value; }
        }

        #endregion

        #region Atributos display
        public bool Enabled
        {
            get { return ComboBoxObjetos.Enabled; }
            set { ComboBoxObjetos.Enabled = value; }
        }
        public String Texto
        {
            get { return ComboBoxObjetos.FieldLabel; }
            set { ComboBoxObjetos.FieldLabel = value; }
        }
        public String TextoVacio
        {
            get { return ComboBoxObjetos.EmptyText; }
            set { ComboBoxObjetos.EmptyText = value; }
        }
        public string AtributoDisplay
        {
            set { ComboBoxObjetos.DisplayField = value; }
        }
        public string AtributoValor
        {
            set { ComboBoxObjetos.ValueField = value; }
        }
        public int Width
        {
            get { return (int)ComboBoxObjetos.Width.Value; }
            set { ComboBoxObjetos.Width = new System.Web.UI.WebControls.Unit(value); }
        }
        #endregion

        public string ValorSeleccionadoComboBox2
        {
            get { return ComboBoxObjetos.Value.ToString(); }
        }

        

        public void OnShowComboBox()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer stc = new WebHelper.Storer(tipoCombo);
                stc.Valores = ValoresCombo;

                if (Select.Equals(""))
                    Select = stc.GetSelect();

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;
                this.SqlDataSource1.SelectCommand = Select;

                stc.ObjectToSqlDataSource(ref SqlDataSource1);
                stc.ObjectToStore(ref Store3);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error en " + this.ID);
            }
        }




        #endregion


        private Type tipo;
        private Permisos permisos = null;

        #region Properties

        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public bool MostrarFiltros
        {
            get { return TopBarFiltros.Visible; }
            set { TopBarFiltros.Visible = value; }
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




        private Entidades.Entity_concepto selectedItem = null;
        public Entidades.Entity_concepto SelectedItem
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
                    concepto.Empresa_idempresa = int.Parse(lista[0]["Empresa_idempresa"]);
                    concepto.Moneda_idmoneda = int.Parse(lista[0]["Moneda_idmoneda"]);
                        

                SelectedItem = concepto;
              
            }
            catch { }

            // TODO
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
                st.Valores = ValoresCombo;
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

        protected void buttonFiltro_OnClick(object sender, DirectEventArgs e)
        {
            string name = comboBox1.Text;
            Atributos a = (new WebHelper.Storer(Tipo)).GetAtributosFromColumna(name);
            Storer st = new WebHelper.Storer(Tipo);
            string valor = Text.Text;
            GridFilter gf = Storer.GetFilter(GridFilters1, a.Nombre);
            try
            {
                switch (Storer.GetBasicType(a.Tipo))
                {
                    case WebHelper.Storer.BasicType.Number:
                        {
                            NumericFilter filtro = (NumericFilter)gf;
                            filtro.SetValue(float.Parse(valor));
                        }
                        break;
                    case WebHelper.Storer.BasicType.Text:
                        {
                            StringFilter filtro = (StringFilter)gf;
                            filtro.SetValue(valor);
                        }
                        break;
                    case WebHelper.Storer.BasicType.Date:
                        {
                            DateFilter filtro = (DateFilter)gf;
                            filtro.SetValue(DateTime.Parse(valor));
                        }
                        break;
                    case WebHelper.Storer.BasicType.Bool:
                        {
                            BooleanFilter filtro = (BooleanFilter)gf;
                            filtro.SetValue(bool.Parse(valor));
                        }
                        break;
                }

                gf.SetActive(true);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        protected void buttonClean_OnClick(object sender, DirectEventArgs e)
        {
            foreach (GridFilter gf in GridFilters1.Filters)
            {
                gf.SetActive(false);
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
                st.Valores = ValoresCombo;
                st.ValoresCombo = ValoresCombo;

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
                // st.ObjectToGridPanel(ref GridPanel1);

                // Permisos de la tabla
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

                cargarFiltros(st);
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

        public void cargarFiltros(Storer st)
        {
            List<object[]> names = new List<object[]>();

            foreach (Atributos s in st.Armador.Atributos)
            {
                //Si no se definió una columna, o si se configuró una columna visible
                //entonces, agregamos el atributo.
                if (s.Columna == null)
                {
                    names.Add(new object[] { s.Nombre, s.Nombre });
                }
                else if (s.Columna.Visible)
                {
                    names.Add(new object[] { s.Nombre, s.Columna.Titulo });
                }
            }

            Store2.DataSource = names;
            Store2.DataBind();

            st.ObjectToFilters(ref this.GridFilters1);
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
                    st.Valores = ValoresCombo;

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
                    st.Valores = ValoresCombo;

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

    }//clase
}//namespace
