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


namespace IU.VentasCuentasCobrar.Comprobantes
{
    public partial class IngresarComprobante : System.Web.UI.Page
    {
      
        private const string sessionCanClick = "CanClickC";
        private const string sessionModificar = "ModificarItemC";

        public object SelectedItem
        {
            get { return Session["ASelitC"]; }
            set { Session["ASelitC"] = value; }
        }

        public object SelectedItemRegimen
        {
            get { return Session["ASelitR"]; }
            set { Session["ASelitR"] = value; }
        }

        public object SelectedId
        {
            get { return Session["ASelidC"]; }
            set { Session["ASelidC"] = value; }
        }

        public object SelectedSituacionImpositiva
        {
            get { return Session["ASitImpositiva"]; }
            set { Session["ASitImpositiva"] = value; }
        }

        public object SelectedTalonarioUtilizdo
        {
            get { return Session["TalonarioUsado"]; }
            set { Session["TalonarioUsado"] = value; }
        }



        public object SelectedDescuentoFinanciero
        {
            get { return Session["DescuentoFinanciero"]; }
            set { Session["DescuentoFinanciero"] = value; }
        }

        public object SelectedDescuentoComercial
        {
            get { return Session["DescuentoComercial"]; }
            set { Session["DescuentoComercial"] = value; }
        }


        public object CheckBoxDescuentoFinanciero
        {
            get { return Session["CheckBoxDescuentoFinanciero"]; }
            set { Session["CheckBoxDescuentoFinanciero"] = value; }
        }

        public object CheckBoxDescuentoComercial
        {
            get { return Session["CheckBoxDescuentoComercial"]; }
            set { Session["CheckBoxDescuentoComercial"] = value; }
        }


        public List<Entity_lineaVenta> ItemsComprobante
        {
            get { return (List<Entity_lineaVenta>)Session["TempLineasComprobante"]; }
            set { Session["TempLineasComprobante"] = value; }
        }


        protected void CargarDatosEnGrid()
        {
            try
            {
                StoreItems.DataSource = ItemsComprobante;
                StoreItems.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
        


           /* if (!ContabilidadGlobal.Admin.Permisos.Alta)
            { 
                Session["Mensaje"] = "Usted no tiene los permisos para acceder a esta sección.";
                Session["Titulo"] = "Acceso denegado";
                Response.Redirect("../../Mensaje.aspx");
            }*/
          //  else 
            if (!X.IsAjaxRequest)
           {
                SelectedItem = null;

                
                TotalDescuentos.Text = "0";
                TotalNeto.Text = "0";
                TotalOtros.Text = "0";
                Total.Text = "0";
                IVA.Text = "0";
                TotalRecargos.Text = "0";

                // Datagrid
                Storer st = new Storer(typeof(Entity_lineaVenta));
                st.ObjectToStore(ref StoreItems);
                st.ObjectToGridPanel(ref GridPanelItems);
                ItemsComprobante = new List<Entity_lineaVenta>();
                CargarDatosEnGrid();

                /* Bugfixer [Ver ingreso de asientos]. */
                Session[sessionCanClick] = true;
                //            }

                ComboMonedas.Tipo = typeof(Entity_moneda);
                ComboMonedas.Width = 300;
                ComboMonedas.OnShow();

                //ComboClientes
                Storer stcli = new Storer(typeof(Entity_cliente));
                OnshowCli(stcli);
                               
                       
                ComboClasesCondicionVenta.Tipo = typeof(Entidades.Entity_condicionesventa);
                ComboClasesCondicionVenta.Width = ComboClasesCondicionVenta.Width;
                ComboClasesCondicionVenta.Valores = new SqlValor[]
            {
            
           new SqlValor ("empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
                ComboClasesCondicionVenta.OnShow();

                ComboClasesProvincia.Tipo = typeof(Entidades.Entity_provincia);
                ComboClasesProvincia.Width = ComboMonedas.Width;
                ComboClasesProvincia.OnShow();

                ComboClasesTipoOperacion.Width = ComboMonedas.Width;

                ComboTipoLista.Tipo = typeof(Entity_tipolista);
                ComboTipoLista.Width = ComboMonedas.Width;
                ComboTipoLista.OnShow();

                // if (Checkbox2.Checked == true) pregunto a la hora de calcular los totales


                //ComboDescuentoFinanciero
                Storer stdesFinan = new Storer(typeof(Entity_descuentosfinancieros));
                OnshowDescF(stdesFinan);

                //ComboDescuentoComercial
                Storer stdesComercial = new Storer(typeof(Entity_descuentoscomerciales));
                OnshowDescComercial(stdesComercial);

             
               // Datagrid conceptos
                Storer sto = new Storer(typeof(Entity_concepto));
               
                //sto.ObjectToSqlDataSource(ref SqlDataSource1);
                OnShow();
                Store1.DataBind();

                //Datagrid regimenes especiales
                OnShowRegimenesEspeciales();
              


           }
        }

       
        private void OnshowDescComercial(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;

            Select = storeCombo.GetSelect();


            this.SqlDataSource4.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource4.ConnectionString = StringConnection;
            this.SqlDataSource4.SelectCommand = Select;

        }

        private void OnshowDescF(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;

            Select = storeCombo.GetSelect();


            this.SqlDataSource5.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource5.ConnectionString = StringConnection;
            this.SqlDataSource5.SelectCommand = Select;

        }

        

        private void OnshowCli(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;
         
            Select = storeCombo.GetSelect();


            this.SqlDataSource2.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource2.ConnectionString = StringConnection;
            this.SqlDataSource2.SelectCommand = Select;

        }



        #region CODIGO DEL ABM GENERICO PARA  CARGAR EL GRID Y LOS FILTROS

        private Type tipo;
        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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
                             

       

 
        public void OnShow()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(typeof(Entity_concepto));
                st.Valores = Valores;
                //st.ValoresCombo = ValoresCombo;

                
                    Select = st.GetSelect();

                this.SqlDataSource3.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource3.ConnectionString = StringConnection;
                this.SqlDataSource3.SelectCommand = Select;


                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref Store1);
                st.ObjectToGridPanel(ref GridPanelConceptos);
                cargarFiltros(st);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }



        public void OnShowRegimenesEspeciales()
        {
            try
            {
                if (StringConnection.Equals(""))
                    StringConnection = CapaDatos.Datos.ConnectionString;

                Storer st = new WebHelper.Storer(typeof(Entity_regimenesEspeciales));
                st.Valores = Valores;
                //st.ValoresCombo = ValoresCombo;

              //  if (Select.Equals(""))
                    Select = st.GetSelect();

                this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
                this.SqlDataSource1.ConnectionString = StringConnection;
                this.SqlDataSource1.SelectCommand = Select;


                st.ObjectToSqlDataSource(ref SqlDataSource1);
                st.ObjectToStore(ref Store3);
                st.ObjectToGridPanel(ref GridPanelRegimenesEspeciales);
                cargarFiltros(st);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }





        public void Reload()
        {
            GridPanelConceptos.Reload();
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


        #endregion



        private void registrarComprobante(DateTime fecha, int codCliente, string letra,
                int numero, DateTime fechaEntrega, DateTime fechaEmision, DateTime fechaContabilizacion,
                DateTime fechaDeclaracionJurada, int prov, bool bienUso, List<Entity_lineaVenta> listaItems, double total,
            bool habilitado, int regimenEspecial, double totalNeto, double totalIva, double totalRecargos,
            double totalDescuentos, double totalOtros, int nroTalonario, int tipoLista)
        {
           

                AdministradorVentas.registrarComprobante(fecha,  codCliente, letra,
                numero, fechaEntrega, fechaEmision, fechaContabilizacion,
                fechaDeclaracionJurada, prov, bienUso, this.ItemsComprobante, total, habilitado, regimenEspecial,
                totalNeto, totalIva, totalRecargos, totalDescuentos, totalOtros, nroTalonario, tipoLista, 1, 1, "1", 1);         
                   
        }

     

     


        #region BUTTONS

        protected void buttonClean_OnClick(object sender, DirectEventArgs e)
        {
            foreach (GridFilter gf in GridFilters1.Filters)
            {
                gf.SetActive(false);
            }
        }

      

        [DirectMethod]
        protected void BotonRegimenEspecial_Click(object sender, DirectEventArgs e)
        {
            WindowRegimenEspecial.Show();
        }

        [DirectMethod]
        protected void BotonAgregar_Click(object sender, DirectEventArgs e)
        {

            int count = ItemsComprobante.Count;
            Session[sessionCanClick] = true; /* Bugfix */
            Session[sessionModificar] = false;
            VentanaMov.Show();
        }

        [DirectMethod]
        protected void BotonQuitar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if (SelectedItem != null)
                {
                    this.RemoveSelected();
                    this.ActualizarTotales();
                    SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }


        [DirectMethod]
        protected void BotonModificar_Click(object sender, DirectEventArgs e)
        {
            Session["Modificar"] = true;
            Session[sessionModificar] = true;
            Session[sessionCanClick] = true; /* Bugfix */
            var row = SelectedItem as Entity_lineaVenta;
            if (row != null)
            {
                Window2.Show();


            }
            //VentanaMov.Show();
        }


        [DirectMethod]
        protected void Window1_BotonAceptar_Click(object sender, DirectEventArgs e)
        {

            Entity_lineaVenta linea = new Entity_lineaVenta();
            var row = SelectedItem as Entity_concepto;

            if (row != null)
            {
                if (ItemsComprobante.Count > 0)
                {
                    int i = ItemsComprobante.Count;
                    linea.Codigo = ItemsComprobante[i - 1].Codigo + 1;
                }
                else
                {
                    linea.Codigo = 1;
                }

                linea.Cantidad = 1;
                linea.Concepto_codConcepto = row.Codconcepto;
                //linea.Concepto_moneda_idmoneda = row.Moneda_idmoneda;
                linea.ImporteNeto = double.Parse(row.PrecioNeto.ToString());
                linea.TasaIva = double.Parse(row.Tasaiva.ToString());
                linea.Importe = double.Parse(row.PrecioFinal.ToString());

                //AGREGA EL ITEM A LA LISTA PERO SIN LA CANTIDAD QUE LA AGREGO EN LA VENTANA 2
                ItemsComprobante.Add(linea);
                // StoreItems.AddRecord(linea, true);
                //StoreItems.CommitChanges(); 

            }
            Session[sessionCanClick] = false; /* Bugfix */
            Window2.Show();

            this.CerrarVentana();
        }


        [DirectMethod]
        protected void WindowRegimenEspecial_BotonAceptar_Click(object sender, DirectEventArgs e)
        {
         Entity_regimenesEspeciales regimen = (Entity_regimenesEspeciales)SelectedItemRegimen;
         RegimenEspecial.Text = regimen.Descripcion;
         WindowRegimenEspecial.Close();
        }


        [DirectMethod]
        protected void Window2_BotonAceptar_Click(object sender, DirectEventArgs e)
        {

            if (!(bool)Session[sessionModificar])
            {
                int i = 0;
                if (ItemsComprobante.Count > 1)
                {
                     i = ItemsComprobante.Count - 1;
                }
                string json = e.ExtraParams["values"];
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, string>>(json);

                ItemsComprobante[i].Cantidad = int.Parse(dict["FieldCantidad"]);

                int cant = int.Parse(dict["FieldCantidad"]);
                double precio = ItemsComprobante[i].Importe;
                ItemsComprobante[i].Importe = cant * precio;
                StoreItems.AddRecord(ItemsComprobante[i], true);
                StoreItems.CommitChanges();
                ActualizarTotales();
                SelectedItem = null;

            }
            else
            {
                Entity_lineaVenta linea = (Entity_lineaVenta)SelectedItem;
                int codigo = 0;
                int i;
                for ( i = 0; i < ItemsComprobante.Count; i++)
                { 
                    if (linea.Codigo == ItemsComprobante[i].Codigo)
                    {
                        codigo = i;
                    }
                }
           

                string json = e.ExtraParams["values"];
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, string>>(json);

                ItemsComprobante[codigo].Cantidad = int.Parse(dict["FieldCantidad"]);

                int cant = int.Parse(dict["FieldCantidad"]);
                double precio = ItemsComprobante[codigo].ImporteNeto +((ItemsComprobante[codigo].ImporteNeto * ItemsComprobante[codigo].TasaIva) / 100);

                ItemsComprobante[codigo].Importe = cant * precio;
                linea.Importe = cant * precio;
                linea.Cantidad = cant;
                
                //Selecciona la fila de nuevo que habia seleccionado para que quede seleccionada
                RowSelectionModel sm = this.GridPanelItems.SelectionModel.Primary as RowSelectionModel;
                sm.SelectedRows.Add(new SelectedRow(codigo.ToString()));
                sm.UpdateSelection();

                //Remuevo de la lista de comprobantes el item
                this.RemoveSelected();

                //Agrego item a la lista con las modificaciones
                ItemsComprobante.Add(linea);
               
                //Inserto en el store
                StoreItems.InsertRecord(codigo, linea, true);                
                StoreItems.CommitChanges();
               
                ActualizarTotales();
                Session[sessionModificar] = false;
                SelectedItem = null;

            }
            this.CerrarVentanaCantidad();
        }

        
        [DirectMethod]
        protected void WindowRegimenEspecial_BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            this.WindowRegimenEspecial.Close();
        }
        

        [DirectMethod]
        protected void Window1_BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            this.CerrarVentana();
        }

        [DirectMethod]
        protected void Window2_BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            CerrarVentanaCantidad();
        }

        
        
        private bool Validar()
        {
            bool respu = false;
            
            if (DateFieldFecha.SelectedDate == DateTime.MinValue && respu == false)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar una fecha",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });

                respu = true;
            }

            if (ComboClasesCliente.Value == null && respu == false)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar un Cliente",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });         
                respu = true;
            }

            if (ComboMonedas.ValorSeleccionado.Length == 0 && respu == false)
            {

                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar una moneda para el comprobante",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });         
                respu = true;
            }
 
            //Valido Nro comprobante
            if (txtNumero.Text.Length == 0 && respu == false)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar un numero de comprobante",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });            
                respu = true;
            }

            if (ComboClasesTipoOperacion.Value == null && respu == false)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar un tipo de operacion",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });
                respu = true;
            }

            if (ItemsComprobante.Count == 0 && respu == false)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos invalidos",
                    Message = "Debe ingresar items al comprobante",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });
                respu = true;
            }
          
            return respu;
        }




        [DirectMethod]
        public void BotonAceptar_Click(object sender, DirectEventArgs e)
        {
                      
                bool respu = Validar();

                if (respu != true)
                {


                   


                        DateTime fecha = DateFieldFecha.SelectedDate;
                        int codCliente = int.Parse(ComboClasesCliente.Value.ToString());
                        int moneda = int.Parse(ComboMonedas.ValorSeleccionado.ToString());
                        string tipoComprobante = txtTipoComprobante.Text;
                        int nroComprobante = int.Parse(txtNumero.Text);
                        string letra = txtLetra.Text.ToString();
                        string casignarSituacionIvacepto = "";
                           casignarSituacionIvacepto= txtConcepto.Text.ToString();
                    double totalNeto =0;
                            //double.Parse(TotalNeto.Text.ToString());
                        double totalIva =0; 
                            //double.Parse(IVA.Text);
                        double totalRecargos =0;
                            //double.Parse(TotalRecargos.Text);
                        double totalDescuentos =0; 
                            //double.Parse(TotalDescuentos.Text);
                        double totalOtros = 0;
                            //double.Parse(TotalOtros.Text);
                        int nroTalonario = int.Parse(SelectedTalonarioUtilizdo.ToString());     //lo calcula en base al nro de comprobante que le ingreso
                        int tipolista = 1;
                    //int.Parse(ComboTipoLista.ValorSeleccionado.ToString());
                        bool habilitado = true;
                        bool bienuso = CheckBoxBienDeUso.Checked;
                        DateTime fechaentrega = DateFieldFechaEntrega.SelectedDate;
                        DateTime fechaemision = DateFieldFechaProbableEmision.SelectedDate;
                        DateTime fechacontabilizacion = DateFieldFechaContabilizacion.SelectedDate;
                        DateTime fechadeclaracionjurada = DateFieldFechaDeclaracionJurada.SelectedDate;
                        int provincia = 1;
                    //int.Parse(ComboClasesProvincia.ValorSeleccionado.ToString());
                        double total = 0;
                            //double.Parse(Total.Text);
                        int regimenEspecial = 1;
                    //int.Parse(RegimenEspecial.Text);
                        // lo debo asignar en una interfaz cuando hago click en el boton regimenes especiales


                        this.registrarComprobante(fecha, codCliente, letra,
                        nroComprobante, fechaentrega, fechaemision, fechacontabilizacion,
                        fechadeclaracionjurada, provincia, bienuso, this.ItemsComprobante, total, habilitado, regimenEspecial,
                        totalNeto, totalIva, totalRecargos, totalDescuentos, totalOtros, nroTalonario, tipolista);

                        AdministradorVentas.IncrementarNroTalonario(nroTalonario);

                        Response.Redirect("IngresarComprobante.aspx");
                    }
                   
                
        }
        
       
        public void asignarSituacionIva(int cod)
        {       
            int cliente = cod;             
            SelectedSituacionImpositiva = AdministradorVentas.ObtenerClienteSituacionIVa(cod);
            
            if (SelectedSituacionImpositiva.ToString() != "No tiene situacion iva")
            {
                this.CalcularNroDeComprobante();
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Datos insuficientes",
                    Message = "El cliente seleccionado, no tiene asignado sus datos impositivos, por favor ingresar datos impositivos del cliente",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });
            
            }
        }


        private void CalcularNroDeComprobante()
        { 
     
          if (SelectedSituacionImpositiva.ToString() == "Inscripto")
          {
            
              int tipoComprobante = 1;
              ArrayList array = AdministradorVentas.ObtenerNroTalonario(tipoComprobante);


              if (array.Count > 0)
              {
                  ArrayList all;
                  all = (ArrayList)array[0];
                  int numero = int.Parse(all[1].ToString());
                  int hasta = int.Parse(all[2].ToString());

                  if (numero < hasta)
                  {

                      txtTipoComprobante.Text = "Nº de Factura";
                      txtLetra.Text = "A";
                      txtNumero.Text = all[1].ToString();
                      SelectedTalonarioUtilizdo = all[0].ToString();
                  }
                  else
                  {
                      X.Msg.Show(new MessageBoxConfig
                      {
                          Title = "Talonario lleno",
                          Message = "El talonario se encuentra utilizado, debe ingresar un nuevo talonario",
                          Buttons = MessageBox.Button.OK,
                          Icon = MessageBox.Icon.INFO,

                      });

                  }
              }
              else
              {

                  X.Msg.Show(new MessageBoxConfig
                  {
                      Title = "Datos insuficientes",
                      Message = "No existe talonario cargado, por favor ingrese un talonario",
                      Buttons = MessageBox.Button.OK,
                      Icon = MessageBox.Icon.INFO,

                  });           
              
              }

          }
          if (SelectedSituacionImpositiva.ToString() == "No inscripto" || SelectedSituacionImpositiva.ToString() == "Consumidor final" || SelectedSituacionImpositiva.ToString() == "Exento")
                {

                    int tipoComprobante = 2;
                    ArrayList array = AdministradorVentas.ObtenerNroTalonario(tipoComprobante);

                    if (array.Count > 0)
                    {
                        ArrayList all;
                        all = (ArrayList)array[0];
                        int numero = int.Parse(all[1].ToString());
                        int hasta = int.Parse(all[2].ToString());

                        if (numero < hasta)
                        {

                            txtTipoComprobante.Text = "Nº de Factura";
                            txtLetra.Text = "B";
                            txtNumero.Text = all[1].ToString();
                            SelectedTalonarioUtilizdo = all[0].ToString();
                        }
                        else
                        {
                            X.Msg.Show(new MessageBoxConfig
                            {
                                Title = "Talonario lleno",
                                Message = "El talonario se encuentra utilizado, debe ingresar un nuevo talonario",
                                Buttons = MessageBox.Button.OK,
                                Icon = MessageBox.Icon.INFO,

                            });

                        }
                    }
                    else
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Datos insuficientes",
                            Message = "No existe talonario cargado, por favor ingrese un talonario",
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.INFO,

                        });                            
                    }

                }


          if (SelectedSituacionImpositiva.ToString() == "Monotributista")
                {
                    int tipoComprobante = 3;
                    ArrayList array = AdministradorVentas.ObtenerNroTalonario(tipoComprobante);

                    if (array.Count > 0)
                    {

                        ArrayList all;
                        all = (ArrayList)array[0];
                        int numero = int.Parse(all[1].ToString());
                        int hasta = int.Parse(all[2].ToString());

                        if (numero < hasta)
                        {

                            txtTipoComprobante.Text = "Nº de Factura";
                            txtLetra.Text = "C";
                            txtNumero.Text = all[1].ToString();
                            SelectedTalonarioUtilizdo = all[0].ToString();
                        }
                        else
                        {
                            X.Msg.Show(new MessageBoxConfig
                            {
                                Title = "Talonario lleno",
                                Message = "El talonario se encuentra utilizado, debe ingresar un nuevo talonario",
                                Buttons = MessageBox.Button.OK,
                                Icon = MessageBox.Icon.INFO,

                            });

                        }
                    }
                    else
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Datos insuficientes",
                            Message = "No existe talonario cargado, por favor ingrese un talonario",
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.INFO,

                        });                            
                    }
                }
        }

        [DirectMethod]
        protected void ChangeHandle(object sender, DirectEventArgs e)
        {
            var item = e.ExtraParams["item"];
            this.SelectedItem = item;
            
        }

        [DirectMethod]
        public void BotonCerrar_Click(object sender, DirectEventArgs e)
        {
            Session["Mensaje"] = "Por favor, cierre la pestaña.";
            Session["Titulo"] = "Operación cancelada";
            Response.Redirect("../../Mensaje.aspx");
        }

        [DirectMethod]
        public void BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            Response.Redirect("IngresarComprobante.aspx");
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


        #endregion

     

        private void QuitarItem(int cod)
        {
            int i = 0;
            while (i < ItemsComprobante.Count && cod != ItemsComprobante[i].Codigo)
            {
                i++;
            }

            if (i < ItemsComprobante.Count)
            {
                ItemsComprobante.RemoveAt(i);
            }
        }

       

        private void RemoveSelected()
        {
            StoreItems.RemoveRecord(SelectedId);
            var item = (Entity_lineaVenta)SelectedItem;
            this.QuitarItem(item.Codigo);
        }


        private void aplicarCondicionVenta()
        {           
        }

        private void ActualizarTotales()
        {
            
            double total=0;
            double totalNeto = 0;
            foreach (var l in ItemsComprobante)
            {
               total +=  l.Importe ;
               totalNeto += l.ImporteNeto * l.Cantidad;
            }            
          
          
            double iva = (totalNeto * 21) / 100;
            IVA.Text = iva.ToString();
          //  double.TryParse(TotalRecargos.Text, out recargos);         
           // double.TryParse(TotalDescuentos.Text, out descuentos); 

            Subtotal.Text = total.ToString();
            Total.Text = total.ToString();            
            TotalNeto.Text = totalNeto.ToString();
            CalcularDescuentoFinanciero();
            CalcularDescuentoComercial();
        }





    
        public void CalcularDescuentoFinanciero()
        {
            if (CheckBoxDescuentoFinanciero != null)
            {

              //  if (ComboBoxDescuentoFinanciero.SelectedItem.Value.ToString() != "")
                //{
                int codigoDescuento = 1;
                        //int.Parse(ComboBoxDescuentoFinanciero.SelectedItem.Value.ToString());
                    ArrayList array = AdministradorVentas.ObtenerDescuentoFinanciero(codigoDescuento);

                    if (array.Count > 0)
                    {
                        ArrayList all;
                        all = (ArrayList)array[0];
                        bool esDescuento = bool.Parse(all[0].ToString());                        
                        double porcentaje = double.Parse(all[1].ToString());


                            double totalDescuentos = 0;
                            double total = 0;                        
                            double.TryParse(Total.Text, out total);

                            totalDescuentos = (total * porcentaje) / 100;

                        if (esDescuento)
                        {

                            if (TotalDescuentos.Text != "")
                            {

                                double totalPanel = double.Parse(TotalDescuentos.Text);
                                totalPanel += totalDescuentos;
                                TotalDescuentos.Text = totalPanel.ToString();

                            }
                            else
                            {
                                TotalDescuentos.Text = totalDescuentos.ToString();
                            }

                            total -= totalDescuentos;
                            Total.Text = total.ToString();
                        }
                        else
                        {
                            if (TotalDescuentos.Text != "")
                            {

                                double totalPanel = double.Parse(TotalRecargos.Text);
                                totalPanel -= totalDescuentos;
                                TotalRecargos.Text = totalPanel.ToString();

                            }
                            else
                            {
                                TotalRecargos.Text = totalDescuentos.ToString();     
                            }

                            total += totalDescuentos;
                            Total.Text = total.ToString();

                      //  }                    
                    }                
                }            
            }      
        }







      public void CalcularDescuentoComercial()
        {
       
            if (CheckBoxDescuentoComercial !=null)
            {
           //     if (ComboBoxDescuentoComercial.SelectedItem.Value.ToString() !="")
             //   {
                int codigoDescuento = 1;
                        //int.Parse(ComboBoxDescuentoComercial.SelectedItem.Value.ToString());
                    ArrayList array = AdministradorVentas.ObtenerDescuentoComercial(codigoDescuento);


                    if (array.Count > 0)
                    {   
                     
                        int i = 0;
                        while (i < array.Count)
                        {
                            ArrayList all;
                            all = (ArrayList)array[i];
                            int esDescuento = 0;
                            int.TryParse(all[1].ToString(), out esDescuento);
                            double porcentaje = double.Parse(all[0].ToString());


                            double totalDescuentos = 0;
                            double total = double.Parse(Total.Text);
                            totalDescuentos = (total * porcentaje) / 100;

                            if (esDescuento == 1)
                            {

                                if (TotalDescuentos.Text != "")
                                {

                                    double totalPanel = double.Parse(TotalDescuentos.Text);
                                    totalPanel += totalDescuentos;
                                    TotalDescuentos.Text = totalPanel.ToString();

                                }
                                else
                                {
                                    TotalDescuentos.Text = totalDescuentos.ToString();
                                }
                                total -= totalDescuentos;
                                Total.Text = total.ToString();
                            }
                            else
                            {
                                if (TotalDescuentos.Text != "")
                                {

                                    double totalPanel = double.Parse(TotalRecargos.Text);
                                    totalPanel -= totalDescuentos;
                                    TotalRecargos.Text = totalPanel.ToString();

                                }
                                else
                                {
                                    TotalRecargos.Text = totalDescuentos.ToString();
                                }
                                total += totalDescuentos;
                                Total.Text = total.ToString();
                            }
                            i++;
                        }//while



                    //}
                }



            }
        }
       





















        #region EVENTOS




        /* Ventana de items  */




        [DirectMethod]
        protected void OnRowSelect_EventItems(object sender, DirectEventArgs e)
        {


            string json = e.ExtraParams["values1"];

            Dictionary<string, string>[] lista = JSON.Deserialize<Dictionary<string, string>[]>(json);

            Entity_lineaVenta linea = new Entity_lineaVenta();
            linea.Codigo = int.Parse(lista[0]["Codigo"]);
            linea.Concepto_codConcepto = int.Parse(lista[0]["Concepto_codConcepto"]);
            linea.Cantidad = int.Parse(lista[0]["Cantidad"]);
            linea.ImporteNeto = double.Parse(lista[0]["ImporteNeto"]);
            linea.TasaIva = double.Parse(lista[0]["TasaIva"]);
            linea.Importe = double.Parse(lista[0]["Importe"]);
            linea.Concepto_moneda_idmoneda = int.Parse(lista[0]["Concepto_moneda_idmoneda"]);

            //"[{\"id\":-69,\"Codigo\":1,\"Concepto_codConcepto\":3,\"Concepto_moneda_idmoneda\":1,\"Cantidad\":43,\"TasaIva\":21,\"ImporteNeto\":100,\"Importe\":182062}]"


            SelectedId = lista[0]["id"];
            Storer st = new Storer(typeof(Entity_lineaVenta));
            SelectedItem = (object)linea;
            //       Entidades.Entity_concepto concept = (Entidades.Entity_concepto)SelectedItem;   


            // TODO
        }



        [DirectMethod]
        protected void OnRowSelect_Event(object sender, DirectEventArgs e)
        {

            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] lista = JSON.Deserialize<Dictionary<string, string>[]>(json);

            Entidades.Entity_concepto conceptoNuevo = new Entity_concepto();

            conceptoNuevo.Codconcepto = int.Parse(lista[0]["Codconcepto"]);
            conceptoNuevo.Descripcion = lista[0]["Descripcion"];
            conceptoNuevo.Clase = lista[0]["Clase"];
            conceptoNuevo.Observaciones = lista[0]["Observaciones"];
            conceptoNuevo.Tipo = lista[0]["Tipo"];
            conceptoNuevo.Tasaiva = double.Parse(lista[0]["Tasaiva"]);
            conceptoNuevo.PrecioNeto = double.Parse(lista[0]["PrecioNeto"]);
            conceptoNuevo.PrecioFinal = double.Parse(lista[0]["PrecioFinal"]);
            //conceptoNuevo.Empresa_idempresa = int.Parse(lista[0]["Empresa_idempresa"]);
            //conceptoNuevo.Moneda_idmoneda = int.Parse(lista[0]["Moneda_idmoneda"]);


            Storer st = new Storer(typeof(Entity_concepto));
            SelectedItem = (object)conceptoNuevo;
            //   Entidades.Entity_concepto concept = (Entidades.Entity_concepto)SelectedItem;       
        }


        [DirectMethod]
        protected void OnRowSelectRegimen_Event(object sender, DirectEventArgs e)
        {

            string json = e.ExtraParams["ValuesRegimen"];
            Dictionary<string, string>[] lista = JSON.Deserialize<Dictionary<string, string>[]>(json);

            Entity_regimenesEspeciales regimen = new Entity_regimenesEspeciales();

            regimen.Idregimen = int.Parse(lista[0]["Idregimen"]);
            regimen.Basecalculo = int.Parse(lista[0]["Basecalculo"]);
            regimen.Computoventascontribuyente = bool.Parse(lista[0]["Computoventascontribuyente"]);
            regimen.Computoventasdgi = bool.Parse(lista[0]["Computoventasdgi"]);
            regimen.Descripcion = lista[0]["Descripcion"];
            regimen.Impuesto = lista[0]["Impuesto"];
            regimen.Monto = float.Parse(lista[0]["Monto"]);
            regimen.Montominimo = float.Parse(lista[0]["Montominimo"]);
            regimen.Percepcionminima = float.Parse(lista[0]["Percepcionminima"]);
            regimen.Porcentaje = float.Parse(lista[0]["Porcentaje"]);
            regimen.Tipomontominimo = int.Parse(lista[0]["Tipomontominimo"]);
            regimen.Tipopercepcionminima = int.Parse(lista[0]["Tipopercepcionminima"]);
            regimen.Tiporegimen_idtiporegimen = int.Parse(lista[0]["Tiporegimen_idtiporegimen"]);

            SelectedItemRegimen = (object)regimen;
             
        }


        #endregion

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        
     

        /// <summary>
        /// Oculta la ventana y resetea todos sus campos.
        /// </summary>
        private void CerrarVentana()
        {
            VentanaMov.Hide();
        }


        private void CerrarVentanaCantidad()
        {
            FieldCantidad.Value = null;
            Window2.Hide();
        }


    }//Clase
}//namespace
