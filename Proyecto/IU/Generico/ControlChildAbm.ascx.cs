using System;
using System.Collections.Generic;
using AdministradorGeneral.Seguridad;
using CapaDatos;
using Ext.Net;
using WebHelper;

namespace IU.Generico
{
    public partial class ControlChildAbm : System.Web.UI.UserControl
    {
        private Type tipo;
        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public void MostrarBotones(bool valor)
        {
            btnDelete.Hidden = valor;
            btnInsert.Hidden = valor;
            btnSave.Hidden = valor;
            btnRefresh.Hidden = valor;
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

        private Permisos permisos = null;
        public Permisos Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

        public bool MostrarDescripcion
        {
            get { return Panel1.Visible; }
            set { Panel1.Visible = value; }
        }

        public event EventHandler AlSeleccionar = null;

        private SqlValor[] valores;
        public SqlValor[] Valores
        {
            get { return valores; }
            set { valores = value; }
        }

        private SqlValor[] valoresCombo;
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
            string json = Session["json"].ToString();
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);

            Storer st = new Storer(Tipo);
            st.Valores = Valores;
            string consulta = st.MakeDeleteRow(companies);
            Datos.ConsultarEx(consulta);

            GridPanel1.Reload();
        }

        protected void btnDelete_OnClick(object sender, DirectEventArgs e)
        {
            Session["json"] = e.ExtraParams["Values"];
            DeleteRow();
        }

        public void OnShow()
        {
            try
            {
                //Harcoded here
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;
                //End hard

                Storer st = new WebHelper.Storer(Tipo);
                st.Valores = Valores;
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
                st.ObjectToGridPanel(ref GridPanel1);

                //Aplicar cuestiones de seguridad
                if (Permisos == null)
                {
                    Permisos = Permisos.PermisosAdmin;
                }

                if (!Permisos.Alta)
                {
                    this.btnInsert.Enabled = false;
                    if (!Permisos.Modif)
                    {
                        this.btnSave.Enabled = false;
                    }
                }
                if (!Permisos.Baja)
                {
                    this.btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        /// <summary>
        /// Actualiza las consultas si se modificaron los sqlvalor.
        /// </summary>
        public void ActualizarConsultas()
        {
            try
            {
                Storer st = new WebHelper.Storer(Tipo);
                st.Valores = Valores;

                Insert = st.GetInsert();
                Select = st.GetSelect();
                Update = st.GetUpdate();
                Delete = st.GetDelete();

                this.SqlDataSource1.InsertCommand = Insert;
                this.SqlDataSource1.SelectCommand = Select;
                this.SqlDataSource1.UpdateCommand = Update;
                this.SqlDataSource1.DeleteCommand = Delete;

                //Solución mágica
                this.Store1.DataBind(); // Linea mágica que trae los nuevos registros
                this.GridPanel1.Reconfigure();
            }
#if DEBUG
            catch(Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error al actualizar referencias");
            }
#else
            catch
            {
                UIHelper.MostrarError("Por favor, recargue la página para solucionar el problema. Si este persiste, por favor, comuníquese con el área de soporte técnico.", "Error al actualizar referencias");
            }
#endif
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
                
        }

        [DirectMethod]
        protected void OnRowSelect_Event(object sender, DirectEventArgs e)
        {
           
            SelectedItem = null;
            try
            {
                string json = e.ExtraParams["Values"];
                Dictionary<string, string>[] rows = JSON.Deserialize<Dictionary<string, string>[]>(json);

                Storer st = new Storer(Tipo);
                st.Valores = Valores;
                SelectedItem = st.MakeObjectFromRow(rows);
            }
            catch { }

            if (AlSeleccionar != null)
            {
                AlSeleccionar.Invoke(this, EventArgs.Empty);
            }
        }

        private object selectedItem = null;
        public object SelectedItem
        {
            get { return selectedItem; }
            protected set { selectedItem = value; }
        }
    }
}