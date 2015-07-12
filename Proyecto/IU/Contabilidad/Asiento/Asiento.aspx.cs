using System;
using System.Collections.Generic;
using Ext.Net;
using Siscont.Contabilidad;
using Traductor;
using WebHelper;

namespace IU.Contabilidad.Asiento
{
    public partial class Asiento : System.Web.UI.Page
    {
        private static string formatoTotales = "Total debe: {0}    Total haber: {1}";

        public List<PreMovimiento> Movimientos
        {
            get { return (List<PreMovimiento>)Session["TempLineasMovs"]; }
            set { Session["TempLineasMovs"] = value; }
        }

        /// <summary>
        /// Para generar el código de los movimientos. Este código se usa para la base
        /// de datos y para identificar los controles dentro del datagrid.
        /// </summary>
        public int TempId
        {
            get { return (int)Session["Tempid"]; }
            set { Session["Tempid"] = value; }
        }

        public float TotalDebe
        {
            get { return (float)Session["TotalDebe"]; }
            set { Session["TotalDebe"] = value; }
        }

        public float TotalHaber
        {
            get { return (float)Session["TotalHaber"]; }
            set { Session["TotalHaber"] = value; }
        }

        public object SelectedItem
        {
            get { return Session["ASelit"]; }
            set { Session["ASelit"] = value; }
        }

        public object SelectedId
        {
            get { return Session["ASelid"]; }
            set { Session["ASelid"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!ContabilidadGlobal.Admin.Permisos.Alta)
            {
                Session["Mensaje"] = "Usted no tiene los permisos para acceder a esta sección.";
                Session["Titulo"] = "Acceso denegado";
                Response.Redirect("../../Mensaje.aspx");
            }
            else*/
            if (!X.IsAjaxRequest)
            {
                SelectedItem = null;
                TempId = 0;

                Storer st = new Storer(typeof(PreMovimiento));
                st.ObjectToStore(ref Store1);

                TextFieldMonto.DecimalSeparator = TraductorHelper.GetSeparador();
                TextFieldMonto.Note = string.Format("Ej.: {0}", Movimiento.ObtenerValorFormateado(150, 25));

                DateFieldAsiento.Value = DateTime.Today;
                CargarDatosEnCombo();
                CargarDatosEnComboMovs();
                Movimientos = new List<PreMovimiento>();
                CargarDatosEnGrid();

                CheckBoxHabilitado.Checked = true;

                /* Bugfixer: al hacer varios clicks en aceptar te agrega muchas veces un mov. */
                Session["CanClick"] = true;
            }
        }

        protected void CargarDatosEnComboMovs()
        {
            try
            {
                StoreComboMov.DataSource = ContabilidadGlobal.Admin.ObtenerListaTiposMovimientos();
                StoreComboMov.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error al cargar tipos de movimientos");
            }
        }

        protected void CargarDatosEnCombo()
        {
            try
            {
                StoreCombo.DataSource = ContabilidadGlobal.Admin.ObtenerListaDescripTiposAsientos();
                StoreCombo.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error al cargar tipos de asiento");
            }
        }

        protected void CargarDatosEnGrid()
        {
            try
            {
                Store1.DataSource = Movimientos ;
                Store1.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        protected void BotonAceptarYContinuar_Click(object sender, DirectEventArgs e)
        {
            var cod = RegistrarAsiento();
            if (cod != -1)
            {
                Response.Redirect("Asiento.aspx");
            }
        }

        [DirectMethod]
        protected void BotonConfirmar_Click(object sender, DirectEventArgs e)
        {
            var cod = RegistrarAsiento();
            if (cod != -1)
            {
                Session["cod"] = cod;
                Response.Redirect("AsientoAgregado.aspx");
            }
        }

        /// <summary>
        /// Registra un asiento.
        /// </summary>
        /// <returns>-1 si error.</returns>
        private int RegistrarAsiento()
        {
            int cod = -1;
            try
            {
                cod = ContabilidadGlobal.Admin.GenerarAsiento(
                    TextFieldNombre.Text,
                    ComboTipoAsiento.Text,
                    DateFieldAsiento.SelectedDate,
                    CheckBoxEditable.Checked,
                    CheckBoxHabilitado.Checked,
                    false,
                    Movimientos.ToArray());
                TextFieldNum.Text = cod.ToString();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }

            return cod;
        }

        [DirectMethod]
        protected void BotonLimpiar_Click(object sender, DirectEventArgs e)
        {
            Response.Redirect("Asiento.aspx");
        }

        [DirectMethod]
        protected void BotonAgregar_Click(object sender, DirectEventArgs e)
        {
            Session["CanClick"] = true; /* Bugfix */
            Session["Modificar"] = false;
            VentanaMov.Show();
            CargarDatosEnComboMovs();
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

        private void QuitarMovimiento(int cod)
        {
            int i = 0;
            while (i < Movimientos.Count && cod != Movimientos[i].Cod)
            {
                i++;
            }

            if (i < Movimientos.Count)
            {
                Movimientos.RemoveAt(i);
            }
        }

        private void RemoveSelected()
        {
            Store1.RemoveRecord(SelectedId);
            var mov = (PreMovimiento)SelectedItem;
            this.QuitarMovimiento(mov.Cod);
        }

        private void ActualizarTotales()
        {
            TotalDebe = 0;
            TotalHaber = 0;
            
            foreach(var l in Movimientos)
            {
                TotalDebe += float.Parse(l.Debe);
                TotalHaber += float.Parse(l.Haber);
            }

            this.LabelTotales.Text = string.Format(Asiento.formatoTotales, TotalDebe, TotalHaber);
        }

        [DirectMethod]
        protected void BotonModificar_Click(object sender, DirectEventArgs e)
        {
            Session["Modificar"] = true;
            Session["CanClick"] = true; /* Bugfix */
            var row = (PreMovimiento)SelectedItem;
            if (row != null)
            {
                TextFieldLeyenda.Text = row.Leyenda;
                TextFieldCuenta.Text = row.Cuenta;
                TextFieldMonto.Text = (float.Parse(row.Debe) == 0) ? row.Haber : row.Debe;
                ComboBoxDebeHaber.Value = (float.Parse(row.Debe) == 0) ? "H" : "D";
                TextFieldDescripcion.Text = row.Descripcion;
            }
            VentanaMov.Show();
        }

        [DirectMethod]
        protected void Window1_BotonAceptar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if ((bool)Session["CanClick"])
                {
                    if (!(bool)Session["Modificar"])
                    {
                        Dictionary<string, string> dict = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
                        var linea = new PreMovimiento
                        {
                            Cod = TempId++,
                            Cuenta = dict["TextFieldCuenta"],
                            Debe = dict["ComboBoxDebeHaber_Value"].Equals("D") ? dict["TextFieldMonto"] : "0",
                            Haber = dict["ComboBoxDebeHaber_Value"].Equals("H") ? dict["TextFieldMonto"] : "0",
                            Descripcion = dict["TextFieldDescripcion"],
                            Leyenda = dict["TextFieldLeyenda"],
                            Tipo = dict["ComboBoxTipoMovimiento_Value"]
                        };
                        Movimientos.Add(linea);
                        Store1.AddRecord(linea, true);

                    }
                    else
                    {
                        var row = (PreMovimiento)SelectedItem;
                        Dictionary<string, string> dict = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
                        var linea = new PreMovimiento
                        {
                            Cod = row.Cod,
                            Cuenta = dict["TextFieldCuenta"],
                            Debe = dict["ComboBoxDebeHaber_Value"].Equals("D") ? dict["TextFieldMonto"] : "0",
                            Haber = dict["ComboBoxDebeHaber_Value"].Equals("H") ? dict["TextFieldMonto"] : "0",
                            Descripcion = dict["TextFieldDescripcion"],
                            Leyenda = dict["TextFieldLeyenda"],
                            Tipo = dict["ComboBoxTipoMovimiento_Value"]
                        };

                        this.RemoveSelected();
                        Movimientos.Add(linea);
                        Store1.InsertRecord(row.Cod, linea, true);
                        RowSelectionModel1.SelectRow(row.Cod);
                    }

                    this.ActualizarTotales();
                }
            }
            catch
            { }

            Session["CanClick"] = false; /* Bugfix */

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

        [DirectMethod]
        protected void OnRowSelect_Event(object sender, DirectEventArgs e)
        {
            SelectedItem = null;
            try
            {
                string json = e.ExtraParams["Values"];
                Dictionary<string, string>[] rows = JSON.Deserialize<Dictionary<string, string>[]>(json);
                SelectedId = rows[0]["id"];
                Storer st = new Storer(typeof(PreMovimiento));
                SelectedItem = st.MakeObjectFromRow(rows);
            }
            catch { }

            // TODO
        }
    }
}
