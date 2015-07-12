using System;
using WebHelper;


namespace IU.Generico
{
    public partial class ComboClases : System.Web.UI.UserControl 
    {
        #region Atributos objeto
        
        private Type tipo;
        public Type Tipo
        {
            get 
            {
                return tipo; 
            }
            set { tipo = value; }
        } 
        
        private SqlValor[] valores;
        /// <summary>
        /// SqlValor aplicado al combo box.
        /// </summary>
        public SqlValor[] Valores
        {
            get { return valores; }
            set { valores = value; }
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
            get { return ComboBoxObjetos.ValueField; }
            set { ComboBoxObjetos.ValueField = value; }
        }
        public int Width
        {
            get { return (int)ComboBoxObjetos.Width.Value; }
            set { ComboBoxObjetos.Width = new System.Web.UI.WebControls.Unit(value); }
        }
        #endregion

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
        #endregion

        public string ValorSeleccionado
        {
            get { return ComboBoxObjetos.Value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void OnShow()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(Tipo);
                st.Valores = Valores;

                if (Select.Equals(""))
                    Select = st.GetSelect();

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;
                this.SqlDataSource1.SelectCommand = Select;

                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref StoreCombo);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error en "+this.ID);
            }
        }
    }
}