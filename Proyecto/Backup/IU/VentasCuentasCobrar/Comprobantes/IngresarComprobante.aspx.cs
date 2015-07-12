using System;
using Ext.Net;
using IU.Contabilidad;
using WebHelper;
using System.Collections.Generic;
using VentasCuentasCobrar;

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

        public object SelectedId
        {
            get { return Session["ASelidC"]; }
            set { Session["ASelidC"] = value; }
        }

        public List<ItemComprobante> ItemsComprobante
        {
            get { return (List<ItemComprobante>)Session["TempLineasComprobante"]; }
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
          //  else if (!X.IsAjaxRequest)
           // {
                SelectedItem = null;

                // Datagrid
                Storer st = new Storer(typeof(ItemComprobante));
                st.ObjectToStore(ref StoreItems);
                st.ObjectToGridPanel(ref GridPanelItems);
                ItemsComprobante = new List<ItemComprobante>();
                CargarDatosEnGrid();

                /* Bugfixer [Ver ingreso de asientos]. */
                Session[sessionCanClick] = true;
                //            }

                ComboMonedas.Tipo = typeof(Entidades.Entity_moneda);
                ComboMonedas.Width = 300;
                ComboMonedas.OnShow();

                ComboClasesCliente.Tipo = typeof(Entidades.Entity_cliente);
                ComboClasesCliente.Width = ComboMonedas.Width;
                ComboClasesCliente.Valores = new SqlValor[]
            {
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
            };
                ComboClasesCliente.OnShow();


                ComboClasesCondicionVenta.Tipo = typeof(Entidades.Entity_condicionesventa);
                ComboClasesCondicionVenta.Width = ComboClasesCondicionVenta.Width;
                ComboClasesCondicionVenta.Valores = new SqlValor[]
            {
            
           new SqlValor ("empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
                ComboClasesCondicionVenta.OnShow();


                //ComboClasesPunto.Tipo = typeof(Entidades.Entity_puntoregistracion);
                //ComboClasesPunto.Width = ComboMonedas.Width;
                //ComboClasesPunto.OnShow();

                ComboClasesProvincia.Tipo = typeof(Entidades.Entity_provincia);
                ComboClasesProvincia.Width = ComboMonedas.Width;
                ComboClasesProvincia.OnShow();

                ComboClasesTipoOperacion.Width = ComboMonedas.Width;

                ComboTipoLista.Tipo = typeof(Entidades.Entity_tipolista);
                ComboTipoLista.Width = ComboMonedas.Width;
                ComboTipoLista.OnShow();

                // if (Checkbox2.Checked == true) pregunto a la hora de calcular los totales

                ComboClases1.Tipo = typeof(Entidades.Entity_descuentoscomerciales);
                ComboClases1.Width = ComboClases1.Width;
                ComboClases1.OnShow();



                //if (Checkbox1.Checked == true) pregunto a la hora de calcular los totales

                ComboClases2.Tipo = typeof(Entidades.Entity_descuentosfinancieros);
                ComboClases2.Width = ComboClases1.Width;
                ComboClases2.OnShow();

        //    }
        }


        private void aplicarDescuentoComerciales()
        {
        
        }

        private void aplicarDescuentoFinancieros() { }

        private int registrarComprobante()
        {

            int cod = -1;
            try
            {
               //


                DateTime fecha = DateFieldFecha.SelectedDate;
                int codCliente = int.Parse(ComboClasesCliente.ValorSeleccionado.ToString());
                char letra = char.Parse(TextField6.Text);
                long numero = long.Parse(TextFieldNum.Text);
                DateTime fechaEntrega = DateFieldFechaEntrega.SelectedDate;
                DateTime fechaEmision = DateFieldFechaProbableEmision.SelectedDate;
                int lote = int.Parse(NumberFieldLote.Text);
                string mensaje = TextFieldMensaje.Text;
                DateTime fechaContabilizacion = DateField1.SelectedDate;
                DateTime fechaDeclaracionJurada = DateField2.SelectedDate;
                int prov = int.Parse(ComboClasesProvincia.ValorSeleccionado.ToString());
                bool bienUso = CheckBoxBienDeUso.Checked;
                double total = double.Parse(TextField5.Text);
                
                bool respu = AdministradorVentas.registrarComprobante(fecha, codCliente, letra, numero, fechaEntrega
                    , fechaEmision, lote, mensaje, fechaContabilizacion, fechaDeclaracionJurada, prov, bienUso
                    , ItemsComprobante, total);



            /*    cod = ContabilidadGlobal.Admin.GenerarAsiento(
                    TextFieldNombre.Text,
                    ComboTipoAsiento.Text,
                    DateFieldAsiento.SelectedDate,
                    CheckBoxEditable.Checked,
                    CheckBoxHabilitado.Checked,
                    false,
                    Movimientos.ToArray());
                TextFieldNum.Text = cod.ToString();*/
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }

            return cod;
        
        
        }

        [DirectMethod]
        public void BotonAceptar_Click(object sender, DirectEventArgs e)
        {

            this.registrarComprobante();

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

        [DirectMethod]
        protected void OnRowSelect_Event(object sender, DirectEventArgs e)
        {
            SelectedItem = null;
            try
            {
                string json = e.ExtraParams["Values"];
                Dictionary<string, string>[] rows = JSON.Deserialize<Dictionary<string, string>[]>(json);
                Storer st = new Storer(typeof(ItemComprobante));
                SelectedId = rows[0][st.Armador.Atributos[0].Nombre];
                SelectedItem = st.MakeObjectFromRow(rows);
            }
            catch { }

            // TODO
        }


        [DirectMethod]
        protected void BotonAgregar_Click(object sender, DirectEventArgs e)
        {
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
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

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

        [DirectMethod]
        protected void BotonModificar_Click(object sender, DirectEventArgs e)
        {
            Session["Modificar"] = true;
            Session[sessionCanClick] = true; /* Bugfix */
            var row = (ItemComprobante)SelectedItem;
            if (row != null)
            {
                /*TextFieldLeyenda.Text = row.Leyenda;
                TextFieldCuenta.Text = row.Cuenta;
                TextFieldMonto.Text = (float.Parse(row.Debe) == 0) ? row.Haber : row.Debe;
                ComboBoxDebeHaber.Value = (float.Parse(row.Debe) == 0) ? "H" : "D";
                TextFieldDescripcion.Text = row.Descripcion;*/
            }
            VentanaMov.Show();
        }

        private void RemoveSelected()
        {
            StoreItems.RemoveRecord(SelectedId);
            var item = (ItemComprobante)SelectedItem;
            this.QuitarItem(item.Codigo);
        }


        private void aplicarCondicionVenta()
        { 
        
        
        
        
        }

        private void ActualizarTotales()
        {
            double total=0;
            foreach (var l in ItemsComprobante)
            {
               total = l.Cantidad * l.Importe;
               total += 10;
            }
            TextField5.Text = total.ToString();

            // Actualizar totales
        }


        /* Ventana de items  */

        [DirectMethod]
        protected void Window1_BotonAceptar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if ((bool)Session[sessionCanClick])
                {
                    if (!(bool)Session[sessionModificar])
                    {
                        Dictionary<string, string> dict = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
                        var linea = new ItemComprobante
                        {
                            Cantidad = int.Parse(dict["NumberFieldCantidad"])
                            /*Cod = TempId++,
                            Cuenta = dict["TextFieldCuenta"],
                            Debe = dict["ComboBoxDebeHaber_Value"].Equals("D") ? dict["TextFieldMonto"] : "0",
                            Haber = dict["ComboBoxDebeHaber_Value"].Equals("H") ? dict["TextFieldMonto"] : "0",
                            Descripcion = dict["TextFieldDescripcion"],
                            Leyenda = dict["TextFieldLeyenda"],
                            Tipo = dict["ComboBoxTipoMovimiento_Value"]*/
                        };
                        ItemsComprobante.Add(linea);
                        StoreItems.AddRecord(linea, true);

                    }
                    else
                    {
                        var row = (ItemComprobante)SelectedItem;
                        Dictionary<string, string> dict = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
                        
                        var linea = new ItemComprobante
                        {
                            Cantidad = int.Parse(dict["NumberFieldCantidad"])
                            /*Cod = row.Cod,
                            Cuenta = dict["TextFieldCuenta"],
                            Debe = dict["ComboBoxDebeHaber_Value"].Equals("D") ? dict["TextFieldMonto"] : "0",
                            Haber = dict["ComboBoxDebeHaber_Value"].Equals("H") ? dict["TextFieldMonto"] : "0",
                            Descripcion = dict["TextFieldDescripcion"],
                            Leyenda = dict["TextFieldLeyenda"],
                            Tipo = dict["ComboBoxTipoMovimiento_Value"]*/
                        };

                        this.RemoveSelected();
                        ItemsComprobante.Add(linea);
                        StoreItems.InsertRecord(row.Codigo, linea, true);
                        RowSelectionModel1.SelectRow(row.Codigo);
                    }

                    this.ActualizarTotales();
                }
            }
            catch
            { }

            Session[sessionCanClick] = false; /* Bugfix */

            this.CerrarVentana();
        }


        [DirectMethod]
        protected void Window1_BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            this.CerrarVentana();
        }

        /// <summary>
        /// Oculta la ventana y resetea todos sus campos.
        /// </summary>
        private void CerrarVentana()
        {
            VentanaMov.Hide();
        }
    }
}
